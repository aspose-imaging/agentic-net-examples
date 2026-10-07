// HOW-TO: Extract Embedded Images from SVG and Save to ZIP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Xml.Linq;
using System.IO.Compression;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.zip";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            XDocument svgDoc = XDocument.Load(inputPath);
            XNamespace svgNs = "http://www.w3.org/2000/svg";
            XNamespace xlinkNs = "http://www.w3.org/1999/xlink";

            var imageElements = svgDoc.Descendants(svgNs + "image");
            var imageDataList = new List<(string Name, byte[] Data)>();
            int unnamedCounter = 1;

            foreach (var img in imageElements)
            {
                string href = (string)img.Attribute(xlinkNs + "href") ?? (string)img.Attribute("href");
                if (string.IsNullOrEmpty(href) || !href.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // data:[<mediatype>][;base64],<data>
                int commaIndex = href.IndexOf(',');
                if (commaIndex < 0) continue;

                string meta = href.Substring(5, commaIndex - 5); // skip "data:"
                string base64Data = href.Substring(commaIndex + 1);

                string mime = "application/octet-stream";
                if (meta.Contains(";"))
                {
                    mime = meta.Split(';')[0];
                }
                else if (!string.IsNullOrWhiteSpace(meta))
                {
                    mime = meta;
                }

                string extension = GetExtensionFromMime(mime);
                string id = (string)img.Attribute("id");
                string name;
                if (!string.IsNullOrWhiteSpace(id))
                {
                    name = $"{id}{extension}";
                }
                else
                {
                    name = $"image{unnamedCounter}{extension}";
                    unnamedCounter++;
                }

                byte[] data;
                try
                {
                    data = Convert.FromBase64String(base64Data);
                }
                catch
                {
                    continue; // skip invalid base64
                }

                imageDataList.Add((name, data));
            }

            using (FileStream zipToOpen = new FileStream(outputPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
            {
                foreach (var (Name, Data) in imageDataList)
                {
                    var entry = archive.CreateEntry(Name, CompressionLevel.Optimal);
                    using (var entryStream = entry.Open())
                    {
                        entryStream.Write(Data, 0, Data.Length);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static string GetExtensionFromMime(string mime)
    {
        switch (mime.ToLowerInvariant())
        {
            case "image/png":
                return ".png";
            case "image/jpeg":
            case "image/jpg":
                return ".jpg";
            case "image/gif":
                return ".gif";
            case "image/bmp":
                return ".bmp";
            case "image/svg+xml":
                return ".svg";
            case "image/webp":
                return ".webp";
            default:
                return ".bin";
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to pull raster PNG or JPEG images embedded as base64 data URIs inside an SVG file for further processing in a C# application.
 * 2. When a web service must generate a downloadable ZIP package containing all embedded images from an SVG diagram to deliver to a client.
 * 3. When converting design assets, you want to separate the bitmap components from an SVG so they can be edited individually in Photoshop or other raster editors.
 * 4. When automating a build pipeline that validates and archives every embedded image in SVG icons by extracting them into a version‑controlled ZIP file.
 * 5. When creating a content‑management workflow that extracts embedded images from SVGs while preserving their original names for metadata indexing.
 */
