using System;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            const int width = 10;
            const int height = 10;
            bool allPassed = true;

            // Test 1: Invert a fully white mask (all opaque) -> should become fully black (all transparent)
            var whiteMask = new ImageGrayscaleMask(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    whiteMask[x, y] = 255;
                }
            }

            var invertedWhite = whiteMask.Invert();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (invertedWhite.GetByteOpacity(x, y) != 0)
                    {
                        allPassed = false;
                        Console.Error.WriteLine($"Test 1 failed at ({x},{y}): expected 0, got {invertedWhite.GetByteOpacity(x, y)}");
                    }
                }
            }

            // Test 2: Invert a fully black mask (all transparent) -> should become fully white (all opaque)
            var blackMask = new ImageGrayscaleMask(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    blackMask[x, y] = 0;
                }
            }

            var invertedBlack = blackMask.Invert();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (invertedBlack.GetByteOpacity(x, y) != 255)
                    {
                        allPassed = false;
                        Console.Error.WriteLine($"Test 2 failed at ({x},{y}): expected 255, got {invertedBlack.GetByteOpacity(x, y)}");
                    }
                }
            }

            if (allPassed)
            {
                Console.WriteLine("All mask inversion tests passed.");
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
 * 1. When a developer needs to verify that inverting a fully opaque (white) ImageGrayscaleMask correctly produces a fully transparent (black) mask for PNG images with an alpha channel.
 * 2. When a developer wants to ensure that the ImageGrayscaleMask.Invert method reliably turns a completely transparent (black) mask into a fully opaque (white) mask before applying watermarks or overlays.
 * 3. When a developer is writing automated unit tests for an image‑processing pipeline that depends on correct mask inversion to generate proper cut‑out effects in JPEG‑2000 or TIFF files.
 * 4. When a developer must confirm that mask inversion works across different image dimensions in C# code that manipulates masks for medical imaging DICOM overlays.
 * 5. When a developer is debugging a custom magic‑wand selection tool and needs to validate that the inversion of extreme mask values behaves as expected in the Aspose.Imaging for .NET library.
 */