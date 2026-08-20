// HOW-TO: Save a GIF to a Network Share Path Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.gif";
        string outputPath = @"\\RemoteServer\SharedFolder\output.gif";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image from the input path
            using (Image image = Image.Load(inputPath))
            {
                // Save the GIF image to the network share
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to move processed GIF files from a local workstation to a shared network folder for team collaboration.
 * 2. When an automated C# service must store generated or converted GIF images on a remote server for centralized access.
 * 3. When a web application creates GIF thumbnails and must save them to a network share that multiple applications read.
 * 4. When a batch job processes GIF animations and writes the results to a UNC path to integrate with existing file‑based workflows.
 * 5. When you want to ensure the output directory on a remote share exists before saving a GIF using Aspose.Imaging in C#.
 */
