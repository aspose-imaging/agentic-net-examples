using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create an input image and write it to a memory stream
            using (MemoryStream inputStream = new MemoryStream())
            {
                StreamSource inputSource = new StreamSource(inputStream);
                PngOptions createOptions = new PngOptions() { Source = inputSource };
                using (Aspose.Imaging.Image inputImage = Aspose.Imaging.Image.Create(createOptions, 200, 200))
                {
                    // Fill the image with red color
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(inputImage);
                    graphics.Clear(Aspose.Imaging.Color.Red);
                    // Save to the bound stream
                    inputImage.Save();
                }

                // Prepare the stream for reading
                inputStream.Position = 0;

                // Load the background image from the memory stream
                using (Aspose.Imaging.Image bgImg = Aspose.Imaging.Image.Load(inputStream))
                {
                    Aspose.Imaging.RasterImage background = (Aspose.Imaging.RasterImage)bgImg;

                    // Create an overlay image in another memory stream
                    using (MemoryStream overlayStream = new MemoryStream())
                    {
                        StreamSource overlaySource = new StreamSource(overlayStream);
                        PngOptions overlayCreateOptions = new PngOptions() { Source = overlaySource };
                        using (Aspose.Imaging.Image overlayImg = Aspose.Imaging.Image.Create(overlayCreateOptions, 100, 100))
                        {
                            Aspose.Imaging.Graphics overlayGraphics = new Aspose.Imaging.Graphics(overlayImg);
                            overlayGraphics.Clear(Aspose.Imaging.Color.Blue);
                            overlayImg.Save();
                        }

                        overlayStream.Position = 0;

                        // Load the overlay image
                        using (Aspose.Imaging.Image ovImg = Aspose.Imaging.Image.Load(overlayStream))
                        {
                            Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)ovImg;

                            // Blend the overlay onto the background at (50,50) with 50% opacity
                            background.Blend(new Aspose.Imaging.Point(50, 50), overlay, 128);
                        }
                    }

                    // Save the blended result to an output memory stream
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        StreamSource outputSource = new StreamSource(outputStream);
                        PngOptions outputOptions = new PngOptions() { Source = outputSource };
                        background.Save(outputStream, outputOptions);

                        Console.WriteLine($"Output image size: {outputStream.Length} bytes");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}