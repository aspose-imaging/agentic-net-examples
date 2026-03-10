using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source WebP file
        string inputPath = "input.webp";

        // Load the WebP image using Aspose.Imaging
        using (WebPImage webPImage = (WebPImage)Image.Load(inputPath))
        {
            // Retrieve the options associated with the loaded WebP image
            WebPOptions options = webPImage.Options;

            // List supported WebP input settings
            Console.WriteLine("Supported WebP Input Settings:");
            Console.WriteLine($"Lossless: {options.Lossless}");
            Console.WriteLine($"Quality: {options.Quality}");
            Console.WriteLine($"AnimBackgroundColor: {options.AnimBackgroundColor}");
            Console.WriteLine($"AnimLoopCount: {options.AnimLoopCount}");
            Console.WriteLine($"BufferSizeHint: {options.BufferSizeHint}");
            Console.WriteLine($"FullFrame: {options.FullFrame}");
            Console.WriteLine($"KeepMetadata: {options.KeepMetadata}");
            Console.WriteLine($"MultiPageOptions: {(options.MultiPageOptions != null ? "Defined" : "None")}");
            Console.WriteLine($"Palette: {(options.Palette != null ? "Defined" : "None")}");
            Console.WriteLine($"ResolutionSettings: {(options.ResolutionSettings != null ? "Defined" : "None")}");
            Console.WriteLine($"Source: {(options.Source != null ? "Defined" : "None")}");
            Console.WriteLine($"VectorRasterizationOptions: {(options.VectorRasterizationOptions != null ? "Defined" : "None")}");
            Console.WriteLine($"XmpData: {(options.XmpData != null ? "Defined" : "None")}");
        }
    }
}