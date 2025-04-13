"use client";

import { useState } from "react";
import { getGames } from "@/services/getGames";
import { Game } from "@/interfaces/Game";
import { Button } from "@/shared/ui/button";

export default function Home() {
  const [games, setGames] = useState<Game[]>([]);

  const LoadGamesHandler = async () => {
      setGames(await getGames());
      console.log("Список игр", games);
  };

  return (
    <div>
      <Button variant={"destructive"} onClick={LoadGamesHandler}>
        Загрузить игры
      </Button>
    </div>
  );
}
