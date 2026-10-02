// HOW-TO: How To Unit Test Mask Union Merging Overlapping Masks In C# (Aspose.Imaging for .NET)
using System;
using System.IO;

namespace MaskUnionTest
{
    class Mask
    {
        private readonly bool[,] _data;
        public int Width { get; }
        public int Height { get; }

        public Mask(int width, int height)
        {
            Width = width;
            Height = height;
            _data = new bool[height, width];
        }

        public void SetPixel(int x, int y, bool value)
        {
            _data[y, x] = value;
        }

        public bool GetPixel(int x, int y)
        {
            return _data[y, x];
        }

        public Mask Union(Mask other)
        {
            if (other.Width != Width || other.Height != Height)
                throw new ArgumentException("Mask dimensions must match for union.");

            Mask result = new Mask(Width, Height);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    result._data[y, x] = this._data[y, x] || other._data[y, x];
                }
            }
            return result;
        }

        public bool Equals(Mask other)
        {
            if (other == null || other.Width != Width || other.Height != Height)
                return false;

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    if (this._data[y, x] != other._data[y, x])
                        return false;

            return true;
        }
    }

    class Program
    {
        static void Main()
        {
            // Hardcoded paths as per priority instruction
            string inputPath = "input.txt";
            string outputPath = "output.txt";

            // Input path check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            try
            {
                // Create first mask (3x3) with true at (0,0) and (1,1)
                Mask mask1 = new Mask(3, 3);
                mask1.SetPixel(0, 0, true);
                mask1.SetPixel(1, 1, true);

                // Create second mask (3x3) with true at (1,1) and (2,2)
                Mask mask2 = new Mask(3, 3);
                mask2.SetPixel(1, 1, true);
                mask2.SetPixel(2, 2, true);

                // Perform union
                Mask combined = mask1.Union(mask2);

                // Expected mask
                Mask expected = new Mask(3, 3);
                expected.SetPixel(0, 0, true);
                expected.SetPixel(1, 1, true);
                expected.SetPixel(2, 2, true);

                // Verify result
                if (combined.Equals(expected))
                {
                    Console.WriteLine("Union test passed.");
                }
                else
                {
                    Console.Error.WriteLine("Union test failed: combined mask does not match expected mask.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify that combining two binary image masks with overlapping areas produces a correct composite mask for image editing pipelines.
 * 2. When writing automated tests for a custom mask class in Aspose.Imaging to ensure the Union method respects dimension checks and logical OR behavior.
 * 3. When integrating mask operations into a C# application that applies selective filters, you need a unit test to confirm overlapping regions are correctly merged.
 * 4. When debugging a graphics workflow that relies on boolean masks, a test confirming the Union result helps catch errors before rendering the final image.
 * 5. When creating a CI pipeline for image processing libraries, you include a mask union test to guarantee consistent behavior across different environments.
 */
