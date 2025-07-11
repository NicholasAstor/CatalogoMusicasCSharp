using System;
using src;
using src.MusicPlayer.Services;

class Program
{
    static void Main(string[] args)
    {
        Author MilesDavis = new Author("Miles Davis", "American", false, "The best jazz musician of all time");
        string filePath = @"C:\Users\Alberto_Borsatto\OneDrive - Dell Technologies\Desktop\code\CatalogoMusicasCSharp\src\MusicPlayer\songs\baby.mp3"; 
        Music music = new Music("", "Test music", 300, Gender.Jazz, MilesDavis, filePath);
        MusicPlayerService musicService = new MusicPlayerService(music);
        
        musicService.Play();
        
        Console.WriteLine("Tocando Miles Davis. Use: ");
        Console.WriteLine("P => Pausar");
        Console.WriteLine("S => Parar");
        Console.WriteLine("R => Retomar");
        Console.WriteLine("Q => Sair");
        
        bool isRunning = true;
        
        while (isRunning)
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.P:
                    musicService.Pause();
                    break;
                case ConsoleKey.R:
                    musicService.Resume();
                    break;
                case ConsoleKey.S:
                    musicService.Stop();
                    break;
                case ConsoleKey.Q:
                    isRunning = false;
                    musicService.Stop();
                    Console.WriteLine("Encerrando...");
                    break;
            }
        }
    }
}