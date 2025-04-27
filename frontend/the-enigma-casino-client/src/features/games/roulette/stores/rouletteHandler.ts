import {
  socketMessageReceived,
  messageSent,
} from "../../../../websocket/store/wsIndex";
import {
  gameStateReceived,
  spinResultReceived,
  betConfirmed,
  betsOpenedReceived,
  betsClosedReceived,
  roulettePausedReceived,
  placeRouletteBet,
  // resetSpinResult,
  countdownTick,
  rouletteStopedReceived,
} from "./rouletteEvents";

socketMessageReceived.watch((data) => {
  if (data.type !== "roulette") return;

  console.log("[🎰 Ruleta] Mensaje recibido:", data);

  switch (data.action) {
    case "game_state":
      gameStateReceived(data);
      if (data.secondsRemaining != null) {
        countdownTick(data.secondsRemaining);
      }
      break;
    case "spin_result":
      spinResultReceived(data);
      console.log("🔍 SPIN RESULT LLEGÓ:", data);
      break;
    case "bet_confirmed":
      betConfirmed(data);
      break;
      case "bets_opened":
        betsOpenedReceived();
        if (data.countdown != null) {
          countdownTick(data.countdown);
        }
        break;
    case "bets_closed":
      betsClosedReceived();
      break;
    case "roulette_paused":
      roulettePausedReceived();
      break;
      case "roulette_stoped":
        rouletteStopedReceived();
        break;
    default:
      console.warn("[Ruleta] Acción desconocida:", data.action);
  }
});

placeRouletteBet.watch((payload) => {
  const message = {
    type: "roulette",
    action: "place_bet",
    ...payload,
  };

  console.log("[🎰 Ruleta] Enviando apuesta:", message);
  messageSent(JSON.stringify(message));
});
