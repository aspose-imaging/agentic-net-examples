using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output\dummy.txt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Determine source format
        FileFormat sourceFormat = Image.GetFileFormat(inputPath);
        Console.WriteLine($"Source format: {sourceFormat}");

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Find all ImageOptions types in the Aspose.Imaging.ImageOptions namespace
            var optionsTypes = Assembly.GetAssembly(typeof(ImageOptionsBase))
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(ImageOptionsBase).IsAssignableFrom(t));

            var destinationFormats = new List<string>();

            foreach (var optType in optionsTypes)
            {
                // Create an instance using the default constructor
                var optionsInstance = Activator.CreateInstance(optType) as ImageOptionsBase;
                if (optionsInstance == null) continue;

                // Check if the loaded image can be saved with these options
                bool canSave = image.CanSave(optionsInstance);
                if (canSave)
                {
                    destinationFormats.Add(optType.Name.Replace("Options", ""));
                }
            }

            Console.WriteLine("Possible destination formats for conversion:");
            foreach (var fmt in destinationFormats.Distinct())
            {
                Console.WriteLine($"- {fmt}");
            }
        }
    }
}