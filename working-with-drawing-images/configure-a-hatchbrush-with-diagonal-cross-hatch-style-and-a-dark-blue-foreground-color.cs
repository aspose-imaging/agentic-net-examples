using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Emf.EmfPlus.Consts;
using Aspose.Imaging.FileFormats.Wmf.Consts;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up BMP options for a new image
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new 500x500 image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Configure HatchBrush with diagonal cross style and dark blue foreground
                HatchBrush brush = new HatchBrush
                {
                    HatchStyle = HatchStyle.DiagonalCross,
                    ForegroundColor = Color.DarkBlue,
                    BackgroundColor = Color.White
                };

                // Create a pen using the hatch brush
                Pen hatchPen = new Pen(brush, 5f);

                // Draw a rectangle using the hatch pen
                graphics.DrawRectangle(hatchPen, new Rectangle(new Point(100, 100), new Size(300, 300)));

                // Save the image (the file is already created via FileCreateSource)
                image.Save();
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
 * 1. When a developer needs to generate a 500×500 BMP file with a patterned border for a printable report, they can use Aspose.Imaging to draw a rectangle with a diagonal‑cross hatch brush in dark blue over a white background.
 * 2. When creating custom UI icons or placeholders in a .NET desktop application, the code can produce a BMP image that shows a dark‑blue diagonal cross hatch fill to indicate a disabled or loading state.
 * 3. When automating the production of watermarked graphics for engineering drawings, a developer can apply a dark‑blue diagonal‑cross hatch brush to highlight selected areas without altering the original vector data.
 * 4. When building a batch image‑processing tool that adds a decorative frame to scanned documents, the HatchBrush configuration lets the tool draw a dark‑blue diagonal‑cross pattern around each page and save the result as a BMP.
 * 5. When generating test images for computer‑vision algorithms that need a known high‑contrast pattern, the code creates a BMP with a dark‑blue diagonal‑cross hatch rectangle that can be used to validate edge‑detection or segmentation routines.
 */