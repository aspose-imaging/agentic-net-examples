using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            File.Copy(inputPath, outputPath, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to move or duplicate a user‑uploaded JPEG image to a web‑server’s PNG assets folder while guaranteeing the target directory exists.
 * 2. When an automated build script must verify that a source image file is present before copying it to a staging location for further processing.
 * 3. When a desktop application offers a “Save As” feature that copies the original picture to a new path with a different extension and creates any missing folders.
 * 4. When a background service processes incoming image files and must safely copy each file to a backup directory, logging an error if the source cannot be found.
 * 5. When a migration tool transfers legacy image files from an old directory structure to a new one, ensuring the destination path is created and handling any I/O exceptions.
 */