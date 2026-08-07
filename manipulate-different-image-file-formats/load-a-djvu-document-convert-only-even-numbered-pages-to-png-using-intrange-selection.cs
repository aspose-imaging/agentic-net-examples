using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage image = (DjvuImage)Image.Load(inputPath))
            {
                var options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to extract and archive only the even‑numbered pages of a multi‑page DjVu file as high‑quality PNG images for a digital library, they can use Aspose.Imaging with IntRange selection in C#.
 * 2. When a document processing pipeline must generate thumbnail previews for every second page of scanned contracts stored in DjVu format, the code can load the DjVu document and save those pages as PNG files.
 * 3. When an e‑learning platform wants to display only the answer sheets (typically on even pages) from DjVu exam papers as PNG images for web viewers, developers can apply an IntRange filter during conversion.
 * 4. When a batch conversion tool needs to reduce storage by converting only the even pages of large DjVu manuals to PNG while ignoring odd pages, the Aspose.Imaging API provides the necessary page‑range handling.
 * 5. When a mobile app requires fast loading of selected pages from a DjVu comic book, converting just the even‑numbered pages to PNG using C# and Aspose.Imaging improves performance and bandwidth usage.
 */