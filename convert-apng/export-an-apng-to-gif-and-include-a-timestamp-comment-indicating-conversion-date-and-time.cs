using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\animation.apng";
        string outputPath = "Output\\animation.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var gifOptions = new GifOptions();
                image.Save(outputPath, gifOptions);
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
 * 1. When a web developer needs to convert animated PNG (APNG) assets to GIF for compatibility with older browsers while embedding a timestamp comment that records the conversion date and time.
 * 2. When a mobile app team wants to generate GIF previews of user‑uploaded APNG stickers and include a metadata comment to track when the conversion was performed.
 * 3. When an e‑learning platform automates the transformation of APNG tutorial animations into GIFs for email newsletters and adds a timestamp comment for audit logging.
 * 4. When a digital marketing analyst batch‑processes APNG campaign banners into GIFs for social media ads and needs a conversion timestamp comment to synchronize publishing schedules.
 * 5. When a desktop publishing software integrates Aspose.Imaging to allow designers to export APNG illustrations as GIFs with an embedded comment showing the exact date and time of conversion for version control.
 */