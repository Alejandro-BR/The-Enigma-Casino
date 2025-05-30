import { createStore } from "effector";
import { getUserHistoryFx } from "./historyEffects";
import type { GameDto } from "./types";
import { getOtherUserHistoryFx } from "../otherProfile/otherProfileEffects";

export const $historyGames = createStore<GameDto[]>([]).on(
  getUserHistoryFx.doneData,
  (_, payload) => payload.gamesDtos
);

export const $historyPage = createStore(1).on(
  getUserHistoryFx.doneData,
  (_, payload) => payload.page
);

export const $historyTotalPages = createStore(1).on(
  getUserHistoryFx.doneData,
  (_, payload) => payload.totalPages
);

export const $otherUserHistory = createStore<GameDto[]>([]).on(
  getOtherUserHistoryFx.doneData,
  (_, payload) => payload.gamesDtos
);
