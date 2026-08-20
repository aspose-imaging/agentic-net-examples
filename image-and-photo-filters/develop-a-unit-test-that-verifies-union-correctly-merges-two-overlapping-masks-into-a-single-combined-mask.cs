// HOW-TO: How To Union Overlapping Rectangle Masks In Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create two overlapping rectangle masks
            RectangleMask rectMask1 = new RectangleMask(30, 30, 100, 100);
            RectangleMask rectMask2 = new RectangleMask(80, 80, 100, 100);

            // Union the masks
            ImageBitMask unionMask = rectMask1.Union(rectMask2);

            // Verify that overlapping and individual areas are opaque
            bool overlapOpaque = unionMask.IsOpaque(90, 90);      // inside both rectangles
            bool firstOnlyOpaque = unionMask.IsOpaque(40, 40);   // inside first rectangle only
            bool outsideTransparent = unionMask.IsTransparent(10, 10); // outside both

            if (overlapOpaque && firstOnlyOpaque && outsideTransparent)
            {
                Console.WriteLine("Union test passed.");
            }
            else
            {
                Console.Error.WriteLine("Union test failed.");
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
 * 1. When you need to programmatically combine multiple selection areas in a PNG to create a single mask for batch image editing.
 * 2. When you want to verify that overlapping rectangular selections produce a unified opaque region in automated unit tests using Aspose.Imaging.
 * 3. When building a C# application that applies effects only to the combined area of several masks, such as highlighting or blurring specific parts of an image.
 * 4. When you must ensure that areas outside all masks remain transparent while the intersecting and individual mask regions stay opaque for compositing layers.
 * 5. When creating a reusable test suite to confirm that the Union operation on ImageBitMask objects works correctly across different image formats like JPEG, BMP, or PNG.
 */
