using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path
        string inputPath = "input.wmf";
        // Output WMF file path
        string outputPath = "output_shifted.wmf";

        // Shift values (positive values shift right and down)
        int shiftX = 20;
        int shiftY = 30;

        // Load the WMF image
        using (WmfImage wmf = (WmfImage)Image.Load(inputPath))
        {
            // Resize the canvas to apply the shift.
            // Negative X/Y moves the existing content right/down by the specified amounts.
            wmf.ResizeCanvas(new Rectangle(-shiftX, -shiftY, wmf.Width + shiftX, wmf.Height + shiftY));

            // Save the shifted WMF image
            wmf.Save(outputPath);
        }
    }
}