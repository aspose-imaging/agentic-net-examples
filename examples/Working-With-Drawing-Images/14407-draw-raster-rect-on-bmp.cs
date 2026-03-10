using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class DrawRasterPortionOnVectorToBmp
{
    static void Main()
    {
        // Paths for source raster image and output BMP
        string dir = @"C:\Temp\";
        string sourcePath = Path.Combine(dir, "source.png");
        string outputPath = Path.Combine(dir, "output.bmp");

        // Load the raster image that will be drawn partially
        using (RasterImage sourceRaster = (RasterImage)Image.Load(sourcePath))
        {
            // Define the size of the vector (EMF) canvas
            int vectorWidth = 800;   // pixels
            int vectorHeight = 600;  // pixels

            // Convert pixel dimensions to millimeters for EMF recorder (1 mm = 0.1 inch, 96 DPI default)
            int vectorWidthMm = (int)(vectorWidth / 100f);
            int vectorHeightMm = (int)(vectorHeight / 100f);

            // Frame rectangle for the EMF image
            Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, vectorWidth, vectorHeight);

            // Create EMF recorder graphics
            EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
                frame,
                new Aspose.Imaging.Size(vectorWidth, vectorHeight),
                new Aspose.Imaging.Size(vectorWidthMm, vectorHeightMm));

            // Define source rectangle (portion of the raster image to copy)
            // Example: take a 200x150 area starting at (50,50) in the source image
            Aspose.Imaging.Rectangle srcRect = new Aspose.Imaging.Rectangle(50, 50, 200, 150);

            // Define destination rectangle (where the portion will be placed in the vector canvas)
            // Example: place it at (100,100) with the same size (no scaling)
            Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(100, 100, 200, 150);

            // Draw the specified portion of the raster image onto the vector canvas
            graphics.DrawImage(sourceRaster, destRect, srcRect, GraphicsUnit.Pixel);

            // Finish recording and obtain the EMF image
            using (Aspose.Imaging.FileFormats.Emf.EmfImage emfImage = graphics.EndRecording())
            {
                // Save the EMF image as a BMP raster image
                using (FileStream outStream = new FileStream(outputPath, FileMode.Create))
                {
                    // BMP save options
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        // Use a stream source that points to the EMF image for rasterization
                        Source = new StreamSource(outStream)
                    };

                    // Save the EMF image to BMP, specifying the bounds of the output bitmap
                    emfImage.Save(outStream, bmpOptions, new Aspose.Imaging.Rectangle(0, 0, vectorWidth, vectorHeight));
                }
            }
        }
    }
}