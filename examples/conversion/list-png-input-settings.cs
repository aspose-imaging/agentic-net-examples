using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source PNG file
        string sourcePath = "input.png";

        // Load the PNG image using Aspose.Imaging
        using (Image image = Image.Load(sourcePath))
        {
            // Cast the generic Image to PngImage to access PNG‑specific members
            PngImage png = image as PngImage;
            if (png == null)
            {
                Console.WriteLine("The loaded file is not a PNG image.");
                return;
            }

            // Retrieve the original PNG saving options (reflects the input settings)
            PngOptions originalOptions = png.GetOriginalOptions() as PngOptions;
            if (originalOptions == null)
            {
                Console.WriteLine("Unable to obtain original PNG options.");
                return;
            }

            // Output the supported PNG input settings
            Console.WriteLine("Supported PNG input settings:");
            Console.WriteLine($"BitDepth          : {originalOptions.BitDepth}");
            Console.WriteLine($"ColorType         : {originalOptions.ColorType}");
            Console.WriteLine($"CompressionLevel  : {originalOptions.PngCompressionLevel}");
            Console.WriteLine($"FilterType        : {originalOptions.FilterType}");
            Console.WriteLine($"Progressive       : {originalOptions.Progressive}");
            Console.WriteLine($"Resolution (H DPI): {originalOptions.ResolutionSettings?.HorizontalDpi}");
            Console.WriteLine($"Resolution (V DPI): {originalOptions.ResolutionSettings?.VerticalDpi}");
            Console.WriteLine($"Palette entries   : {(originalOptions.Palette != null ? originalOptions.Palette.Length.ToString() : "None")}");
            Console.WriteLine($"KeepMetadata      : {originalOptions.KeepMetadata}");
        }
    }
}