using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG file path
        string inputPath = "input.jpg";
        // Output JPEG file path with thumbnail inserted
        string outputPath = "output_with_thumbnail.jpg";

        // Load the JPEG image
        using (JpegImage jpegImage = new JpegImage(inputPath))
        {
            // Create a thumbnail raster image (100x100 pixels)
            using (RasterImage thumbnail = (RasterImage)Image.Create(new JpegOptions(), 100, 100))
            {
                // Fill the thumbnail with a solid red color
                Graphics graphics = new Graphics(thumbnail);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, thumbnail.Bounds);

                // Ensure JFIF data container exists
                if (jpegImage.Jfif == null)
                {
                    jpegImage.Jfif = new JFIFData();
                }

                // Assign the thumbnail to the JFIF segment
                jpegImage.Jfif.Thumbnail = thumbnail;

                // Save the JPEG image with the new thumbnail
                jpegImage.Save(outputPath);
            }
        }
    }
}