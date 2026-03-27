using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Images\sample.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            var exif = image.ExifData;
            if (exif == null)
            {
                Console.WriteLine("No EXIF data found.");
                return;
            }

            Console.WriteLine("EXIF Tags");
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("{0,-20} {1}", "Tag", "Value");
            Console.WriteLine(new string('-', 80));

            // Iterate over generic EXIF properties collection if available
            if (exif.Properties != null)
            {
                foreach (var prop in exif.Properties)
                {
                    // Attempt to retrieve TagId and Value via reflection
                    var tagIdProp = prop.GetType().GetProperty("TagId");
                    var valueProp = prop.GetType().GetProperty("Value");
                    string tag = tagIdProp != null ? tagIdProp.GetValue(prop).ToString() : prop.ToString();
                    string value = valueProp != null ? valueProp.GetValue(prop)?.ToString() : "";
                    Console.WriteLine("{0,-20} {1}", tag, value);
                }
            }

            // Additionally display known EXIF fields via reflection
            var exifType = typeof(ExifData);
            foreach (var p in exifType.GetProperties())
            {
                if (p.Name == "Properties") continue; // Skip collection already processed
                var val = p.GetValue(exif);
                if (val != null)
                {
                    Console.WriteLine("{0,-20} {1}", p.Name, val);
                }
            }

            // Display maker notes if present
            if (exif.MakerNotes != null)
            {
                Console.WriteLine("\nMaker Notes");
                Console.WriteLine(new string('-', 80));
                foreach (var note in exif.MakerNotes)
                {
                    Console.WriteLine("Name = {0}, Value = {1}", note.Name, note.Value);
                }
            }
        }
    }
}