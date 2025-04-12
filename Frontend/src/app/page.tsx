"use client"

import { useState } from "react";
import { getGames } from "@/services/getGames";
import { Game } from "@/interfaces/Game";
import { Button } from "@/shared/ui/button";

export default function Home() {
  const [games, setGames] = useState<Game[]>([]);

  const LoadGamesHandler = async () => {
    getGames().then((data) => {
      setGames(data);
      console.log("Список игр", games);
    })
    .catch((error) => console.log("Ошибка при загрузке игр:", error))
  }


  return (
    <div>
      <Button variant={"destructive"} onClick={LoadGamesHandler}>Загрузить игры</Button>
    </div>
  );
}
