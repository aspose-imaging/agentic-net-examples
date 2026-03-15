using System;

class Program
{
    static void Main(string[] args)
    {
        // Determine the image file path (use first argument or a default placeholder)
        string inputPath = args.Length > 0 ? args[0] : "sample.jpg";

        // Load the image into a RasterImage instance
        using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // The image is now in memory and ready for further processing
            Console.WriteLine($"Image loaded: {inputPath}");
            Console.WriteLine($"Dimensions: {image.Width}x{image.Height}");
        }
    }
}