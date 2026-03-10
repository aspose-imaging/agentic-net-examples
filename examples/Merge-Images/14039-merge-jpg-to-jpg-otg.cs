using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ImageMerger
{
    static void Main()
    {
        // Paths of the JPEG images to merge
        string[] sourceFiles = { "image1.jpg", "image2.jpg", "image3.jpg" };

        // Load the first image – it will serve as the canvas for merging
        using (RasterImage canvas = (RasterImage)Image.Load(sourceFiles[0]))
        {
            // Iterate over the remaining images and blend each onto the canvas
            for (int i = 1; i < sourceFiles.Length; i++)
            {
                using (RasterImage overlay = (RasterImage)Image.Load(sourceFiles[i]))
                {
                    // Blend the overlay onto the canvas at the top‑left corner (0,0)
                    // Opacity 255 = fully opaque
                    canvas.Blend(new Point(0, 0), overlay, 255);
                }
            }

            // Save the merged result as a JPEG (OTG format is not a separate format;
            // we use standard JPEG saving options)
            var jpegOptions = new JpegOptions();
            canvas.Save("merged_output.jpg", jpegOptions);
        }
    }
}