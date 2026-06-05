using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cmx";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX vector image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Calculate new dimensions (scale factor 2.0)
                int newWidth = cmxImage.Width * 2;
                int newHeight = cmxImage.Height * 2;

                // Configure BMP save options for 24‑bit color
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        PageWidth = newWidth,
                        PageHeight = newHeight,
                        BackgroundColor = Color.White
                    }
                };

                // Save the rasterized image as BMP
                cmxImage.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a CAD system exports designs as CMX vector files and a developer needs to generate high‑resolution 24‑bit BMP thumbnails for a web gallery, they can use this code to scale the drawing by 2× and rasterize it to BMP.
 * 2. When an engineering workflow requires converting legacy CorelDRAW CMX drawings into printable BMP images with double size for inclusion in technical documentation, this snippet provides the necessary scaling and color‑depth conversion.
 * 3. When a Windows desktop application must display CMX vector graphics on screens that only support bitmap formats, the code can be used to rasterize the vectors at twice their original dimensions and save them as 24‑bit BMP files.
 * 4. When an automated batch process needs to archive CMX files as lossless BMP images with increased resolution for quality‑controlled archiving, the example shows how to apply a 2.0 scaling factor and enforce 24‑bit color.
 * 5. When a GIS tool imports CMX map symbols and must export them as larger BMP icons for use in mobile apps, this code demonstrates loading the CMX, scaling it, and saving it as a 24‑bit BMP.
 */