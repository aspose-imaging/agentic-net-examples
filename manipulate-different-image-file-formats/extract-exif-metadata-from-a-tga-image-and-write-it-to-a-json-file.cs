using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output/metadata.json";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image and extract metadata via reflection
        using (Image image = Image.Load(inputPath))
        {
            var metadata = new Dictionary<string, object>();
            var imgType = image.GetType();

            // List of TGA-specific metadata properties to extract
            var propertyNames = new[]
            {
                "DateTimeStamp",
                "AuthorName",
                "AuthorComments",
                "ImageId",
                "JobNameOrId",
                "JobTime",
                "TransparentColor",
                "SoftwareId",
                "SoftwareVersion",
                "SoftwareVersionLetter",
                "SoftwareVersionNumber",
                "XOrigin",
                "YOrigin",
                "HasAlpha",
                "HasColorMap",
                "Height",
                "Width",
                "IsGrayScale",
                "GammaValueNumerator",
                "GammaValueDenominator",
                "PixelAspectRatioNumerator",
                "PixelAspectRatioDenominator"
            };

            foreach (var propName in propertyNames)
            {
                var propInfo = imgType.GetProperty(propName);
                if (propInfo != null)
                {
                    var value = propInfo.GetValue(image);
                    if (value is DateTime dt)
                    {
                        metadata[propName] = dt.ToString("o");
                    }
                    else if (value is DateTime? ndt)
                    {
                        metadata[propName] = ndt.HasValue ? ndt.Value.ToString("o") : null;
                    }
                    else if (value is TimeSpan ts)
                    {
                        metadata[propName] = ts.ToString();
                    }
                    else if (value is TimeSpan? nts)
                    {
                        metadata[propName] = nts.HasValue ? nts.Value.ToString() : null;
                    }
                    else if (value is Aspose.Imaging.Color color)
                    {
                        metadata[propName] = color.ToArgb();
                    }
                    else
                    {
                        metadata[propName] = value;
                    }
                }
            }

            // EXIF data (if present)
            var exifProp = imgType.GetProperty("ExifData");
            if (exifProp != null)
            {
                var exifData = exifProp.GetValue(image);
                if (exifData != null)
                {
                    var exifType = exifData.GetType();
                    var exifProps = new[] { "ExifVersion", "Make", "Model", "Orientation", "Software" };
                    foreach (var propName in exifProps)
                    {
                        var propInfo = exifType.GetProperty(propName);
                        if (propInfo != null)
                        {
                            var value = propInfo.GetValue(exifData);
                            metadata[$"Exif_{propName}"] = value;
                        }
                    }
                }
            }

            // Build simple JSON string manually
            var sb = new System.Text.StringBuilder();
            sb.Append("{");
            bool first = true;
            foreach (var kvp in metadata)
            {
                if (!first) sb.Append(",");
                first = false;
                sb.Append($"\"{kvp.Key}\":");
                if (kvp.Value == null)
                {
                    sb.Append("null");
                }
                else if (kvp.Value is string str)
                {
                    string escaped = str.Replace("\\", "\\\\").Replace("\"", "\\\"");
                    sb.Append($"\"{escaped}\"");
                }
                else if (kvp.Value is bool b)
                {
                    sb.Append(b.ToString().ToLower());
                }
                else
                {
                    sb.Append(kvp.Value);
                }
            }
            sb.Append("}");
            string json = sb.ToString();

            // Write JSON to file
            File.WriteAllText(outputPath, json);
        }
    }
}