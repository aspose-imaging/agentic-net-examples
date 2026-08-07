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
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Create a thumbnail raster image (100x100)
                int thumbWidth = 100;
                int thumbHeight = 100;
                JpegOptions thumbOptions = new JpegOptions();

                using (RasterImage thumb = (RasterImage)Image.Create(thumbOptions, thumbWidth, thumbHeight))
                {
                    // Fill thumbnail with solid red color
                    Graphics graphics = new Graphics(thumb);
                    SolidBrush brush = new SolidBrush(Color.Red);
                    graphics.FillRectangle(brush, thumb.Bounds);

                    // Assign thumbnail to JFIF segment
                    jpegImage.Jfif = new JFIFData();
                    jpegImage.Jfif.Thumbnail = thumb;

                    // Save the modified JPEG image
                    jpegImage.Save(outputPath);
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
 * 1. When generating product catalog JPEGs, a developer can embed a 100×100 red thumbnail in the JFIF segment to provide fast preview images for file explorers and e‑commerce platforms.
 * 2. When building a digital asset management system, adding a custom thumbnail to the JPEG’s JFIF data ensures consistent thumbnail previews across browsers and legacy image viewers.
 * 3. When converting raw camera files to JPEG, a developer may create and assign a small JFIF thumbnail so that older photo applications can display a quick preview without decoding the full image.
 * 4. When delivering JPEG images through a web API, embedding a solid‑color thumbnail in the JFIF segment allows client applications to show a lightweight visual cue before downloading the high‑resolution picture.
 * 5. When preparing JPEG attachments for email, inserting a custom 100×100 thumbnail into the JFIF segment enables email clients to render a thumbnail preview while keeping the attachment size low.
 */