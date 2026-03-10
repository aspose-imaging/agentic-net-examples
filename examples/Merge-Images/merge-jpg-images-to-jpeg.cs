using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Graphics;
using Aspose.Imaging.Color;

class JpegMergeExample
{
    static void Main()
    {
        // Input JPEG files to be merged (vertical stacking)
        string[] inputFiles = new string[]
        {
            @"C:\Temp\image1.jpg",
            @"C:\Temp\image2.jpg",
            @"C:\Temp\image3.jpg"
        };

        // Output merged JPEG file
        string outputFile = @"C:\Temp\merged_output.jpg";

        // Determine the width (max) and total height of the resulting image
        int mergedWidth = 0;
        int mergedHeight = 0;

        foreach (string file in inputFiles)
        {
            // Load each source JPEG using the load rule
            using (RasterImage src = (RasterImage)Image.Load(file))
            {
                if (src.Width > mergedWidth)
                    mergedWidth = src.Width;          // keep the widest image width
                mergedHeight += src.Height;           // sum heights for vertical merge
            }
        }

        // Create a new blank JPEG image with the calculated dimensions
        JpegOptions createOptions = new JpegOptions
        {
            // Optional: set quality or other save options here
            Quality = 100
        };

        // Use the create rule to instantiate a raster image
        using (RasterImage mergedImage = (RasterImage)Image.Create(createOptions, mergedWidth, mergedHeight))
        {
            // Prepare a graphics object for drawing onto the merged image
            using (Graphics graphics = new Graphics(mergedImage))
            {
                int currentY = 0; // Y‑offset for the next image

                // Draw each source image onto the merged canvas
                foreach (string file in inputFiles)
                {
                    using (RasterImage src = (RasterImage)Image.Load(file))
                    {
                        // If the source width is smaller than the canvas, fill the remaining area with white
                        if (src.Width < mergedWidth)
                        {
                            // Fill the full row with white background first
                            graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, currentY, mergedWidth, src.Height));
                        }

                        // Draw the source image at the current Y position
                        graphics.DrawImage(src, new Rectangle(0, currentY, src.Width, src.Height));

                        // Advance the Y offset for the next image
                        currentY += src.Height;
                    }
                }
            }

            // Save the merged image using the save rule (JPEG format)
            mergedImage.Save(outputFile);
        }

        Console.WriteLine("Images merged successfully to: " + outputFile);
    }
}