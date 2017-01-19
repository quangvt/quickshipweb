using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickShipWeb.Helpers1
{
    public class CustomAttribute
    {
        
    }

    public class MaxWordsAttribute : ValidationAttribute,
        IClientValidatable
    {
        public MaxWordsAttribute(int maxWords)
            : base("Too many words in {0}")
        {
            maxWords = maxWords;
        }

        public int MaxWords { get; set; }

        protected override ValidationResult IsValid(
            object value, 
            ValidationContext validationContext)
        {
            if (value != null)
            {
                var wordCount = value.ToString().Split(' ').Length;
                if(wordCount > MaxWords)
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage =
                FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("wordcount", MaxWords);
            rule.ValidationType = "maxwords";
            yield return rule;
        }
    }
}