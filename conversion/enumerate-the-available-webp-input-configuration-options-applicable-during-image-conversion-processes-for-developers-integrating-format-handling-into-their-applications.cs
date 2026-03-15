using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source WebP file (replace with an actual file path)
        string inputPath = "input.webp";

        // Load the WebP image using Aspose.Imaging's Load method (lifecycle rule)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WebPImage to access WebP‑specific options
            WebPImage webpImage = image as WebPImage;
            if (webpImage == null)
            {
                Console.WriteLine("The loaded file is not a WebP image.");
                return;
            }

            // Retrieve the WebPOptions associated with the image
            WebPOptions options = webpImage.Options;

            // Enumerate and display all configurable input options
            Console.WriteLine("Available WebP Input Configuration Options:");
            Console.WriteLine($"AnimBackgroundColor : {options.AnimBackgroundColor}");
            Console.WriteLine($"AnimLoopCount       : {options.AnimLoopCount}");
            Console.WriteLine($"BufferSizeHint      : {options.BufferSizeHint}");
            Console.WriteLine($"FullFrame           : {options.FullFrame}");
            Console.WriteLine($"KeepMetadata        : {options.KeepMetadata}");
            Console.WriteLine($"Lossless            : {options.Lossless}");
            Console.WriteLine($"Quality             : {options.Quality}");
            Console.WriteLine($"Source              : {options.Source}");
            Console.WriteLine($"VectorRasterizationOptions : {options.VectorRasterizationOptions}");
            Console.WriteLine($"ResolutionSettings  : {options.ResolutionSettings}");
            Console.WriteLine($"MultiPageOptions    : {options.MultiPageOptions}");
            Console.WriteLine($"Palette             : {options.Palette}");
            Console.WriteLine($"ProgressEventHandler: {options.ProgressEventHandler}");
            Console.WriteLine($"XmpData             : {options.XmpData}");
        }
    }
}