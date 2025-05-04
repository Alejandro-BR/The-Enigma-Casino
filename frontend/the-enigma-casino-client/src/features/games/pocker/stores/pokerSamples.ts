import { sample } from "effector";
import { $currentTableId } from "../../../gameTables/store/tablesIndex";
import { sendPokerAction } from "./pokerIndex";
import { messageSent } from "../../../../websocket/store/wsIndex";

sample({
  clock: sendPokerAction,
  source: $currentTableId,
  fn: (tableId, { move, amount }) => {
    const payload = {
      type: "poker",
      action: "player_action",
      tableId: String(tableId),
      move,
      ...(move === "raise" || move === "all-in"
        ? { amount }
        : {}),
    };

    const message = JSON.stringify(payload, ["type", "action", "tableId", "move", "amount"]);
    console.log("📤 Enviando al WS:", message);

    return message;
  },
  target: messageSent,
});



