// HOW-TO: Apply Manual Polygon Mask to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a point array for manual masking
            PointF[] maskPoints = new PointF[]
            {
                new PointF(50, 50),
                new PointF(150, 50),
                new PointF(150, 150),
                new PointF(50, 150)
            };

            // Build the manual mask using the point array
            GraphicsPath manualMask = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new PolygonShape(maskPoints));
            manualMask.AddFigure(figure);

            // Set up manual masking arguments
            Aspose.Imaging.Masking.Options.ManualMaskingArgs args = new Aspose.Imaging.Masking.Options.ManualMaskingArgs
            {
                Mask = manualMask
            };

            // Configure PNG export options
            PngOptions exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure masking options
            Aspose.Imaging.Masking.Options.MaskingOptions maskingOptions = new Aspose.Imaging.Masking.Options.MaskingOptions
            {
                Method = Aspose.Imaging.Masking.Options.SegmentationMethod.Manual,
                Decompose = false,
                Args = args,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Load the source image and apply manual masking
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Aspose.Imaging.Masking.ImageMasking masking = new Aspose.Imaging.Masking.ImageMasking(image);
                using (Aspose.Imaging.Masking.Result.MaskingResult result = masking.Decompose(maskingOptions))
                {
                    using (Image processed = result[1].GetImage())
                    {
                        processed.Save(outputPath, exportOptions);
                    }
                }
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
 * 1. When you need to hide or remove a specific rectangular area of a PNG by defining custom polygon coordinates in C#.
 * 2. When you want to highlight a region of a PNG for a web thumbnail by applying a manual mask with Aspose.Imaging.
 * 3. When you must protect sensitive information in a PNG by masking it with a user‑defined shape before publishing.
 * 4. When you are generating product images that require a consistent cut‑out shape, such as a square or custom polygon, using a point array in C#.
 * 5. When you need to programmatically apply a transparent overlay to a PNG based on precise coordinates for automated reporting or UI assets.
 */
