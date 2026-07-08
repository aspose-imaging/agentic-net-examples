using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                // Resize to 150x150 using bicubic (CubicConvolution) interpolation
                tiff.Resize(150, 150, ResizeType.CubicConvolution);

                // Save the resized image as PNG
                PngOptions pngOptions = new PngOptions();
                tiff.Save(outputPath, pngOptions);
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
 * 1. When a web application must generate a 150 × 150 PNG thumbnail from a high‑resolution TIFF scan for fast preview in a gallery, a developer can use this C# Aspose.Imaging code with bicubic resizing.
 * 2. When an e‑commerce platform needs to create small PNG preview images from large multi‑page TIFF product manuals for mobile devices, this snippet provides the required image processing in .NET.
 * 3. When a document management system must convert uploaded TIFF files into lightweight PNG thumbnails for indexing and search results, the code demonstrates how to resize using cubic convolution interpolation.
 * 4. When a desktop utility has to batch‑process archival TIFF photographs into 150 × 150 PNG icons for a Windows Explorer thumbnail view, the example shows the necessary C# operations with Aspose.Imaging.
 * 5. When a digital asset pipeline requires consistent high‑quality PNG thumbnails from varied TIFF sources for a content‑delivery network, this example illustrates the use of ResizeType.CubicConvolution in .NET.
 */