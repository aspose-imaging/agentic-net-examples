// HOW-TO: How To Test ImageGrayscaleMask Inversion For White And Black Masks In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.png";
            string outputPathWhite = "output/output_white.png";
            string outputPathBlack = "output/output_black.png";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathWhite));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathBlack));

            // Test 1: Fully white mask inversion
            ImageGrayscaleMask whiteMask = new ImageGrayscaleMask(10, 10);
            // Fill mask with opaque (255)
            for (int y = 0; y < whiteMask.Height; y++)
            {
                for (int x = 0; x < whiteMask.Width; x++)
                {
                    whiteMask[x, y] = 255;
                }
            }

            // Invert mask
            ImageGrayscaleMask invertedWhite = whiteMask.Invert();

            // Verify all pixels are transparent (0)
            bool whiteTestPassed = true;
            for (int y = 0; y < invertedWhite.Height; y++)
            {
                for (int x = 0; x < invertedWhite.Width; x++)
                {
                    if (invertedWhite.GetByteOpacity(x, y) != 0)
                    {
                        whiteTestPassed = false;
                        break;
                    }
                }
                if (!whiteTestPassed) break;
            }

            Console.WriteLine($"White mask inversion test passed: {whiteTestPassed}");

            // Optionally save the inverted mask as a PNG for visual inspection
            using (RasterImage img = (RasterImage)Image.Create(new PngOptions { Source = new FileCreateSource(outputPathWhite, false) }, invertedWhite.Width, invertedWhite.Height))
            {
                img.Save();
            }

            // Test 2: Fully black mask inversion
            ImageGrayscaleMask blackMask = new ImageGrayscaleMask(10, 10);
            // By default mask is transparent (0), ensure it is fully black (already 0)

            // Invert mask
            ImageGrayscaleMask invertedBlack = blackMask.Invert();

            // Verify all pixels are opaque (255)
            bool blackTestPassed = true;
            for (int y = 0; y < invertedBlack.Height; y++)
            {
                for (int x = 0; x < invertedBlack.Width; x++)
                {
                    if (invertedBlack.GetByteOpacity(x, y) != 255)
                    {
                        blackTestPassed = false;
                        break;
                    }
                }
                if (!blackTestPassed) break;
            }

            Console.WriteLine($"Black mask inversion test passed: {blackTestPassed}");

            // Optionally save the inverted mask as a PNG for visual inspection
            using (RasterImage img = (RasterImage)Image.Create(new PngOptions { Source = new FileCreateSource(outputPathBlack, false) }, invertedBlack.Width, invertedBlack.Height))
            {
                img.Save();
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
 * 1. When you need to ensure that a fully opaque (white) grayscale mask becomes completely transparent after inversion, you can write a unit test using Aspose.Imaging to validate the behavior.
 * 2. When verifying that a fully transparent (black) mask correctly turns fully opaque after calling the Invert method, a C# unit test helps prevent regression in image masking logic.
 * 3. When integrating mask inversion into an automated image processing pipeline, testing both extreme mask states guarantees reliable results for downstream compositing.
 * 4. When debugging custom watermark or alpha‑channel manipulation code, confirming mask inversion with unit tests speeds up identification of logical errors.
 * 5. When building a library that supports PNG export with proper alpha handling, unit tests for white and black mask inversion ensure compliance with the Aspose.Imaging API.
 */
