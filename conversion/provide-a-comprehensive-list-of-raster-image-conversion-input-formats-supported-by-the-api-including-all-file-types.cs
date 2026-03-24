using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input path (not used for actual loading in this example)
        string inputPath = @"C:\temp\input.placeholder";

        // Verify that the input file exists; if not, write an error and exit.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output path (not used for actual saving in this example)
        string outputPath = @"C:\temp\output.placeholder";

        // Ensure the output directory exists before any potential save operation.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Retrieve the registered image loading formats (raster input formats).
        FileFormat registeredFormats = ImageLoadersRegistry.RegisteredFormats;

        Console.WriteLine("Supported raster image input formats (Aspose.Imaging):");
        // Enumerate all defined flags in the FileFormat enum.
        foreach (FileFormat format in Enum.GetValues(typeof(FileFormat)))
        {
            // Skip the 'Unknown' and 'Custom' entries.
            if (format == FileFormat.Unknown || format == FileFormat.Custom)
                continue;

            // Check if the current flag is present in the registered formats.
            if ((registeredFormats & format) == format)
            {
                Console.WriteLine($"- {format}");
            }
        }
    }
}