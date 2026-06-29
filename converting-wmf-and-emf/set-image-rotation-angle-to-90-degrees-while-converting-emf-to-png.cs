using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.emf";
        string outputPath = "output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate the image 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Save the rotated image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a Windows application generates vector graphics as EMF files that need to be displayed on a web page, a developer can rotate the image 90 degrees and convert it to PNG for browser compatibility.
 * 2. When an automated report generator creates EMF charts that are oriented incorrectly, the code can be used to rotate the chart 90 degrees and save it as a PNG thumbnail for inclusion in PDF summaries.
 * 3. When a batch processing pipeline must standardize legacy EMF icons to a consistent orientation and raster format, this snippet rotates each icon 90 degrees and outputs PNG files for use in mobile apps.
 * 4. When a document conversion service receives EMF diagrams that must be displayed in landscape mode on a touchscreen kiosk, the developer can apply a 90‑degree rotation and convert them to PNG for fast rendering.
 * 5. When a CI/CD build step needs to verify visual assets by converting rotated EMF logos into PNG snapshots for visual regression testing, this code performs the rotation and format conversion automatically.
 */