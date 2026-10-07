// HOW-TO: Verify PNG Mask Inversion for White and Black Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "MaskInversionTests");
            string inputWhitePath = Path.Combine(baseDir, "input_white.png");
            string inputBlackPath = Path.Combine(baseDir, "input_black.png");
            string outputFromWhitePath = Path.Combine(baseDir, "output_from_white.png");
            string outputFromBlackPath = Path.Combine(baseDir, "output_from_black.png");

            // Ensure directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(inputWhitePath));
            Directory.CreateDirectory(Path.GetDirectoryName(inputBlackPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputFromWhitePath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputFromBlackPath));

            // Create a 10x10 white image
            if (!File.Exists(inputWhitePath))
            {
                var whiteOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(inputWhitePath, false)
                };
                using (RasterImage whiteImg = (RasterImage)Image.Create(whiteOptions, 10, 10))
                {
                    int[] whitePixels = new int[10 * 10];
                    for (int i = 0; i < whitePixels.Length; i++) whitePixels[i] = unchecked((int)0xFFFFFFFF);
                    whiteImg.SaveArgb32Pixels(new Rectangle(0, 0, 10, 10), whitePixels);
                    whiteImg.Save();
                }
            }

            // Create a 10x10 black image
            if (!File.Exists(inputBlackPath))
            {
                var blackOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(inputBlackPath, false)
                };
                using (RasterImage blackImg = (RasterImage)Image.Create(blackOptions, 10, 10))
                {
                    int[] blackPixels = new int[10 * 10];
                    for (int i = 0; i < blackPixels.Length; i++) blackPixels[i] = unchecked((int)0xFF000000);
                    blackImg.SaveArgb32Pixels(new Rectangle(0, 0, 10, 10), blackPixels);
                    blackImg.Save();
                }
            }

            // Test inversion on white mask
            if (!File.Exists(inputWhitePath))
            {
                Console.Error.WriteLine($"File not found: {inputWhitePath}");
                return;
            }
            using (RasterImage imgWhite = (RasterImage)Image.Load(inputWhitePath))
            {
                MagicWandTool.Select(imgWhite, new MagicWandSettings(0, 0))
                    .Invert()
                    .Apply();
                imgWhite.Save(outputFromWhitePath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }

            // Verify result for white mask inversion (should become black)
            bool whiteTestPassed = false;
            if (File.Exists(outputFromWhitePath))
            {
                using (RasterImage resultWhite = (RasterImage)Image.Load(outputFromWhitePath))
                {
                    var pixel = resultWhite.GetPixel(0, 0);
                    whiteTestPassed = pixel.ToArgb() == unchecked((int)0xFF000000);
                }
            }
            Console.WriteLine(whiteTestPassed ? "TestWhiteMaskInversion Passed" : "TestWhiteMaskInversion Failed");

            // Test inversion on black mask
            if (!File.Exists(inputBlackPath))
            {
                Console.Error.WriteLine($"File not found: {inputBlackPath}");
                return;
            }
            using (RasterImage imgBlack = (RasterImage)Image.Load(inputBlackPath))
            {
                MagicWandTool.Select(imgBlack, new MagicWandSettings(0, 0))
                    .Invert()
                    .Apply();
                imgBlack.Save(outputFromBlackPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }

            // Verify result for black mask inversion (should become white)
            bool blackTestPassed = false;
            if (File.Exists(outputFromBlackPath))
            {
                using (RasterImage resultBlack = (RasterImage)Image.Load(outputFromBlackPath))
                {
                    var pixel = resultBlack.GetPixel(0, 0);
                    blackTestPassed = pixel.ToArgb() == unchecked((int)0xFFFFFFFF);
                }
            }
            Console.WriteLine(blackTestPassed ? "TestBlackMaskInversion Passed" : "TestBlackMaskInversion Failed");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to ensure that a PNG mask correctly flips from fully opaque to fully transparent using Aspose.Imaging unit tests.
 * 2. When validating that mask inversion works for both white (opaque) and black (transparent) source images in automated CI pipelines.
 * 3. When creating regression tests to detect bugs in the Aspose.Imaging MagicWand mask handling for different color types.
 * 4. When preparing sample images and verifying that the SaveArgb32Pixels method produces the expected inverted mask results.
 * 5. When integrating image preprocessing steps that require reliable mask inversion before further analysis or compositing.
 */
