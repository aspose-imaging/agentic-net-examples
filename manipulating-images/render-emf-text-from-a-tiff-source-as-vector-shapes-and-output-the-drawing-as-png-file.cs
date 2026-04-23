using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string emfOutputPath = "output.emf";
            string pngOutputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(emfOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

            // Load the TIFF image
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Configure EMF rasterization options to render text as vector shapes
                EmfRasterizationOptions emfRasterOptions = new EmfRasterizationOptions
                {
                    PageSize = tiffImage.Size,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    BackgroundColor = Color.White
                };

                // Set up EMF save options
                EmfOptions emfOptions = new EmfOptions
                {
                    VectorRasterizationOptions = emfRasterOptions
                };

                // Save the TIFF content as EMF (vector format)
                tiffImage.Save(emfOutputPath, emfOptions);
            }

            // Load the generated EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(emfOutputPath))
            {
                // Configure PNG rasterization options to rasterize the EMF vector data
                VectorRasterizationOptions pngRasterOptions = new VectorRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Color.White
                };

                // Set up PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = pngRasterOptions
                };

                // Save the EMF as a PNG file
                emfImage.Save(pngOutputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}