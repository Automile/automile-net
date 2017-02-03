using System.Collections.Generic;

namespace Automile.Net
{
    public class CustomCategoryModel
    {
        public int CustomCategoryId { get; set; }
        public string Value { get; set; }
    }

    public class CustomCategoryPostModel
    {
        public int ContactId { get; set; }

        /// <summary>
        /// Custom categories to add
        /// </summary>
        public List<string> Added { get; set; }

        /// <summary>
        /// Custom categories to delete
        /// </summary>
        public List<int> Removed { get; set; }
    }
}