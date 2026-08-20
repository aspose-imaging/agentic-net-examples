// HOW-TO: Create Diagonal Cross Hatch Brush with Dark Blue Color in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

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

            // Configure a HatchBrush with diagonal cross hatch style
            HatchBrush brush = new HatchBrush();
            brush.HatchStyle = HatchStyle.DiagonalCross;          // Diagonal cross pattern
            brush.ForegroundColor = Color.DarkBlue;               // Dark blue hatch lines
            // BackgroundColor can be left as default or set as needed
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When generating a BMP report that requires a diagonal cross hatch background to highlight sections, you can use this brush configuration.
 * 2. When adding a dark‑blue patterned overlay to an image for branding or UI themes, the HatchBrush setup provides the needed style.
 * 3. When creating custom fill patterns for vector shapes in a diagram generated with Aspose.Imaging, the diagonal cross hatch brush defines the texture.
 * 4. When implementing a watermark that uses a repeating hatch pattern to obscure sensitive information while keeping the image readable, this code creates the appropriate brush.
 * 5. When designing printable graphics such as engineering schematics that need a distinct cross‑hatch shading to differentiate materials, the configured HatchBrush supplies the pattern.
 */
