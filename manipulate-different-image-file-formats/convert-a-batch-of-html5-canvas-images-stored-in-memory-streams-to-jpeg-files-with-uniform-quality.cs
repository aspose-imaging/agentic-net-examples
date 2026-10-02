// HOW-TO: Convert In-Memory Canvas PNG Streams to JPEG with Fixed Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            var images = new List<(string FileName, byte[] Data)>
            {
                ("canvas1.png", new byte[0]),
                ("canvas2.png", new byte[0])
            };

            foreach (var (fileName, data) in images)
            {
                string outputPath = Path.Combine(outputDirectory, $"{Path.GetFileNameWithoutExtension(fileName)}.jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (MemoryStream ms = new MemoryStream(data))
                using (Image image = Image.Load(ms))
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.Quality = 90;
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate JPEG thumbnails from HTML5 canvas images that are kept in memory before saving them to disk.
 * 2. When a web service receives canvas PNG data as byte arrays and must store them as compressed JPEG files for archival.
 * 3. When you want to batch‑process user‑drawn canvas images on the server and enforce a uniform JPEG quality to reduce file size.
 * 4. When converting uploaded canvas screenshots to JPEG format for compatibility with legacy image viewers.
 * 5. When automating the export of in‑memory canvas graphics to a folder structure for further processing in a .NET application.
 */
