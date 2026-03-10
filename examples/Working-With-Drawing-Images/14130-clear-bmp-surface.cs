using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Graphics;
using Aspose.Imaging;

// Create a BMP image of 200x200 pixels
using (BmpImage bmpImage = new BmpImage(200, 200))
{
    // Initialize Graphics object for the BMP image
    using (Graphics graphics = new Graphics(bmpImage))
    {
        // Clear the entire surface with a solid color (e.g., LightGray)
        graphics.Clear(Color.LightGray);
    }

    // Save the cleared BMP image to a file
    string outputPath = Path.Combine(Environment.CurrentDirectory, "cleared.bmp");
    bmpImage.Save(outputPath);
}