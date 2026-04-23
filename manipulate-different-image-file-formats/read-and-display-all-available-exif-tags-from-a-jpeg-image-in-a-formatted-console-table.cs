using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                ExifData exifData = image.ExifData;

                if (exifData == null)
                {
                    Console.WriteLine("No EXIF data found.");
                    return;
                }

                Console.WriteLine("EXIF Tags:");
                Console.WriteLine(new string('-', 60));
                Console.WriteLine("{0,-30} {1}", "Tag", "Value");
                Console.WriteLine(new string('-', 60));

                foreach (ExifProperties tag in Enum.GetValues(typeof(ExifProperties)))
                {
                    object value = exifData.GetTagValue(tag);
                    if (value != null)
                    {
                        Console.WriteLine("{0,-30} {1}", tag, value);
                    }
                }

                Console.WriteLine(new string('-', 60));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}