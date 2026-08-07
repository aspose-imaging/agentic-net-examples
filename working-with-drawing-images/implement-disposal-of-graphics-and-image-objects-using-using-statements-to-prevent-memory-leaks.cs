using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Graphics does not implement IDisposable, so it is not wrapped in a using block
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.Wheat);

                    // Draw a blue rectangle
                    graphics.DrawRectangle(new Pen(Color.Blue, 5), new Rectangle(50, 50, 400, 400));

                    // Draw a string with a solid brush
                    using (SolidBrush brush = new SolidBrush(Color.Red))
                    {
                        graphics.DrawString("Hello Aspose.Imaging", new Font("Arial", 24), brush, new PointF(100, 250));
                    }

                    // Save the image
                    image.Save();
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
 * 1. When a server‑side C# service creates dynamic PNG graphics such as charts or badges and uses Aspose.Imaging’s Image and Graphics objects, wrapping them in using statements guarantees that file streams and image memory are freed after each request.
 * 2. When an automated reporting tool programmatically draws text and shapes onto a 500 × 500 PNG thumbnail and must prevent memory leaks during batch processing of thousands of images.
 * 3. When a desktop application generates custom icons by clearing a background, drawing rectangles and strings, and needs deterministic disposal of the Image and any brush resources to keep the UI responsive.
 * 4. When a background job adds a red watermark text to PNG files stored in a file system and uses a SolidBrush inside a using block to ensure the brush is released along with the image.
 * 5. When a cloud function creates temporary PNG files for email attachments, writes them via a FileStream, and relies on nested using statements to automatically close the stream and release the Aspose.Imaging graphics resources after the email is sent.
 */