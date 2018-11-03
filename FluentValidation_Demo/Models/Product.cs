using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Text.RegularExpressions;

namespace FluentValidation_Demo.Models
{
    [Validator(typeof(ProductValidator))]
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductNumber { get; set; }
        public string ProductionDescription { get; set; }
        public DateTime ProductAvailabilityDate { get; set; }
        public bool DiscountAvailable { get; set; }
        public float MaxDiscount { get; set; }
    }

    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductId).Must(BeAValidGuid).When(product => product.ProductId != null);
            RuleFor(product => product.ProductName).Must(BeAValidAlpha);
            RuleFor(product => product.ProductNumber).Must(BeAValidInteger);
            RuleFor(product => product.ProductAvailabilityDate).Must(BeAValidDate);
        }

        private bool BeAValidGuid(Guid unValidatedGuid)
        {
            try
            {
                if(unValidatedGuid != Guid.Empty && unValidatedGuid != null )
                {
                    if (Guid.TryParse(unValidatedGuid.ToString(), out Guid validatedGuid))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool BeAValidAlphaNumeric(string unvalidatedString)
        {
            try
            {
                Regex reg = new Regex("^[a-zA-Z0-9]*$");
                if(reg.IsMatch(unvalidatedString))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool BeAValidAlpha(string unvalidatedString)
        {
            try
            {
                if(!String.IsNullOrEmpty(unvalidatedString))
                {
                    Regex reg = new Regex("^[a-zA-Z]*$");
                    if (reg.IsMatch(unvalidatedString))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool BeAValidInteger(int? unvalidatedInt)
        {
            try
            {
                if (int.TryParse(unvalidatedInt.ToString(), out int validatedInt))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool BeAValidDate(DateTime unvalidatedDate)
        {
            try
            {
                if (DateTime.TryParse(unvalidatedDate.ToString(), out DateTime validatedDate))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool BeAValidBool(bool unvalidatedBool)
        {
            try
            {
                if (bool.TryParse(unvalidatedBool.ToString(), out bool validatedBool))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}