using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\bmp_parameters.txt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image (or any image) to demonstrate conversion options
        using (Image image = Image.Load(inputPath))
        {
            // Create BmpOptions instance to list supported parameters
            BmpOptions options = new BmpOptions();

            // Example values for demonstration purposes
            options.BitsPerPixel = 24;                                   // Bits per pixel
            options.Compression = BitmapCompression.Rgb;                 // Compression type
            options.ResolutionSettings = new ResolutionSetting(96.0, 96.0); // DPI settings
            options.Source = new FileCreateSource(outputPath, false);    // Output source
            // Palette, KeepMetadata, FullFrame, etc., remain at defaults

            // Collect information about each supported option
            var lines = new List<string>();
            lines.Add("Supported BMP conversion parameters and options:");
            lines.Add($"BitsPerPixel (int): {options.BitsPerPixel}");
            lines.Add($"Compression (BitmapCompression): {options.Compression}");
            lines.Add($"ResolutionSettings: Horizontal={options.ResolutionSettings?.HorizontalResolution} DPI, Vertical={options.ResolutionSettings?.VerticalResolution} DPI");
            lines.Add($"Source: {options.Source?.ToString()}");
            lines.Add($"Palette: {(options.Palette != null ? "Defined" : "null")}");
            lines.Add($"KeepMetadata (bool): {options.KeepMetadata}");
            lines.Add($"FullFrame (bool): {options.FullFrame}");
            lines.Add($"BufferSizeHint (int): {options.BufferSizeHint}");
            lines.Add($"MultiPageOptions: {(options.MultiPageOptions != null ? "Defined" : "null")}");
            lines.Add($"VectorRasterizationOptions: {(options.VectorRasterizationOptions != null ? "Defined" : "null")}");
            lines.Add($"ExifData: {(options.ExifData != null ? "Defined" : "null")}");
            lines.Add($"XmpData: {(options.XmpData != null ? "Defined" : "null")}");
            lines.Add($"ProgressEventHandler: {(options.ProgressEventHandler != null ? "Defined" : "null")}");

            // Write the enumeration to the output file
            File.WriteAllLines(outputPath, lines);

            // Also display the information on the console
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}