using System;
using System.IO;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine(Path.GetTempPath(), "dummy_input.txt");
            string outputPath = Path.Combine(Path.GetTempPath(), "dummy_output.txt");

            // Ensure input file exists
            File.WriteAllText(inputPath, string.Empty);
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create two grayscale masks of size 100x100
            ImageGrayscaleMask mask1 = new ImageGrayscaleMask(100, 100);
            ImageGrayscaleMask mask2 = new ImageGrayscaleMask(100, 100);

            // Fill mask1 with an opaque rectangle (10,10)-(39,39)
            for (int y = 10; y < 40; y++)
            {
                for (int x = 10; x < 40; x++)
                {
                    mask1[x, y] = 255;
                }
            }

            // Fill mask2 with an opaque rectangle (30,30)-(69,69) overlapping mask1
            for (int y = 30; y < 70; y++)
            {
                for (int x = 30; x < 70; x++)
                {
                    mask2[x, y] = 255;
                }
            }

            // Perform union of the two masks
            ImageGrayscaleMask unionMask = mask1.Union(mask2);
            bool insideBoth = unionMask.IsOpaque(35, 35); // overlapped area
            bool onlyMask1 = unionMask.IsOpaque(15, 15); // only in mask1
            bool onlyMask2 = unionMask.IsOpaque(60, 60); // only in mask2
            bool outside = unionMask.IsOpaque(5, 5);    // outside both

            Console.WriteLine(insideBoth && onlyMask1 && onlyMask2 && !outside
                ? "Union test passed"
                : "Union test failed");

            // Cleanup temporary files
            if (File.Exists(inputPath)) File.Delete(inputPath);
            if (File.Exists(outputPath)) File.Delete(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}