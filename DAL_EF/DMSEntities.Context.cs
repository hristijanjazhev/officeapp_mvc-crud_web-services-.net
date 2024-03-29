﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DAL_EF
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class DMSEntities : DbContext
{
    public DMSEntities()
        : base("name=DMSEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Agreement> Agreements { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<Notice> Notices { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Person> People { get; set; }


    public virtual int spAddress_Delete(Nullable<int> addressId)
    {

        var addressIdParameter = addressId.HasValue ?
            new ObjectParameter("AddressId", addressId) :
            new ObjectParameter("AddressId", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddress_Delete", addressIdParameter);
    }


    public virtual ObjectResult<spAddress_GetAddress_Result> spAddress_GetAddress(string street, string number)
    {

        var streetParameter = street != null ?
            new ObjectParameter("Street", street) :
            new ObjectParameter("Street", typeof(string));


        var numberParameter = number != null ?
            new ObjectParameter("Number", number) :
            new ObjectParameter("Number", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spAddress_GetAddress_Result>("spAddress_GetAddress", streetParameter, numberParameter);
    }


    public virtual int spAddress_Update(Nullable<int> addressId, string street, string number, string postalCode, string city, string state, string province, string country, Nullable<int> active, Nullable<int> deleted)
    {

        var addressIdParameter = addressId.HasValue ?
            new ObjectParameter("AddressId", addressId) :
            new ObjectParameter("AddressId", typeof(int));


        var streetParameter = street != null ?
            new ObjectParameter("Street", street) :
            new ObjectParameter("Street", typeof(string));


        var numberParameter = number != null ?
            new ObjectParameter("Number", number) :
            new ObjectParameter("Number", typeof(string));


        var postalCodeParameter = postalCode != null ?
            new ObjectParameter("PostalCode", postalCode) :
            new ObjectParameter("PostalCode", typeof(string));


        var cityParameter = city != null ?
            new ObjectParameter("City", city) :
            new ObjectParameter("City", typeof(string));


        var stateParameter = state != null ?
            new ObjectParameter("State", state) :
            new ObjectParameter("State", typeof(string));


        var provinceParameter = province != null ?
            new ObjectParameter("Province", province) :
            new ObjectParameter("Province", typeof(string));


        var countryParameter = country != null ?
            new ObjectParameter("Country", country) :
            new ObjectParameter("Country", typeof(string));


        var activeParameter = active.HasValue ?
            new ObjectParameter("Active", active) :
            new ObjectParameter("Active", typeof(int));


        var deletedParameter = deleted.HasValue ?
            new ObjectParameter("Deleted", deleted) :
            new ObjectParameter("Deleted", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddress_Update", addressIdParameter, streetParameter, numberParameter, postalCodeParameter, cityParameter, stateParameter, provinceParameter, countryParameter, activeParameter, deletedParameter);
    }


    public virtual int spOrganization_Delete(Nullable<int> organizationId)
    {

        var organizationIdParameter = organizationId.HasValue ?
            new ObjectParameter("OrganizationId", organizationId) :
            new ObjectParameter("OrganizationId", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spOrganization_Delete", organizationIdParameter);
    }


    public virtual ObjectResult<spOrganization_GetOrganization_Result> spOrganization_GetOrganization(string organizationName, string companyId)
    {

        var organizationNameParameter = organizationName != null ?
            new ObjectParameter("OrganizationName", organizationName) :
            new ObjectParameter("OrganizationName", typeof(string));


        var companyIdParameter = companyId != null ?
            new ObjectParameter("CompanyId", companyId) :
            new ObjectParameter("CompanyId", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spOrganization_GetOrganization_Result>("spOrganization_GetOrganization", organizationNameParameter, companyIdParameter);
    }


    public virtual int spOrganization_UpdateOrganization(Nullable<int> organizationId, string organizationName, string companyId, string vatNumber, string description, string email, string phoneNumber, string type, Nullable<int> addressId, Nullable<int> active, Nullable<int> deleted)
    {

        var organizationIdParameter = organizationId.HasValue ?
            new ObjectParameter("OrganizationId", organizationId) :
            new ObjectParameter("OrganizationId", typeof(int));


        var organizationNameParameter = organizationName != null ?
            new ObjectParameter("OrganizationName", organizationName) :
            new ObjectParameter("OrganizationName", typeof(string));


        var companyIdParameter = companyId != null ?
            new ObjectParameter("CompanyId", companyId) :
            new ObjectParameter("CompanyId", typeof(string));


        var vatNumberParameter = vatNumber != null ?
            new ObjectParameter("VatNumber", vatNumber) :
            new ObjectParameter("VatNumber", typeof(string));


        var descriptionParameter = description != null ?
            new ObjectParameter("Description", description) :
            new ObjectParameter("Description", typeof(string));


        var emailParameter = email != null ?
            new ObjectParameter("Email", email) :
            new ObjectParameter("Email", typeof(string));


        var phoneNumberParameter = phoneNumber != null ?
            new ObjectParameter("PhoneNumber", phoneNumber) :
            new ObjectParameter("PhoneNumber", typeof(string));


        var typeParameter = type != null ?
            new ObjectParameter("Type", type) :
            new ObjectParameter("Type", typeof(string));


        var addressIdParameter = addressId.HasValue ?
            new ObjectParameter("AddressId", addressId) :
            new ObjectParameter("AddressId", typeof(int));


        var activeParameter = active.HasValue ?
            new ObjectParameter("Active", active) :
            new ObjectParameter("Active", typeof(int));


        var deletedParameter = deleted.HasValue ?
            new ObjectParameter("Deleted", deleted) :
            new ObjectParameter("Deleted", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spOrganization_UpdateOrganization", organizationIdParameter, organizationNameParameter, companyIdParameter, vatNumberParameter, descriptionParameter, emailParameter, phoneNumberParameter, typeParameter, addressIdParameter, activeParameter, deletedParameter);
    }


    public virtual int spPerson_Delete(Nullable<int> personId)
    {

        var personIdParameter = personId.HasValue ?
            new ObjectParameter("PersonId", personId) :
            new ObjectParameter("PersonId", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spPerson_Delete", personIdParameter);
    }


    public virtual ObjectResult<spPerson_GetAll_Result> spPerson_GetAll()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spPerson_GetAll_Result>("spPerson_GetAll");
    }


    public virtual ObjectResult<spPerson_GetLastName_Result> spPerson_GetLastName(string personLastName, string eMBG)
    {

        var personLastNameParameter = personLastName != null ?
            new ObjectParameter("PersonLastName", personLastName) :
            new ObjectParameter("PersonLastName", typeof(string));


        var eMBGParameter = eMBG != null ?
            new ObjectParameter("EMBG", eMBG) :
            new ObjectParameter("EMBG", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spPerson_GetLastName_Result>("spPerson_GetLastName", personLastNameParameter, eMBGParameter);
    }


    public virtual ObjectResult<Nullable<decimal>> spPerson_InsertAddress(string street, Nullable<int> number, Nullable<int> postalCode, string city, string state, string provice, string country, Nullable<int> isActive, Nullable<int> isDeleted)
    {

        var streetParameter = street != null ?
            new ObjectParameter("Street", street) :
            new ObjectParameter("Street", typeof(string));


        var numberParameter = number.HasValue ?
            new ObjectParameter("Number", number) :
            new ObjectParameter("Number", typeof(int));


        var postalCodeParameter = postalCode.HasValue ?
            new ObjectParameter("PostalCode", postalCode) :
            new ObjectParameter("PostalCode", typeof(int));


        var cityParameter = city != null ?
            new ObjectParameter("City", city) :
            new ObjectParameter("City", typeof(string));


        var stateParameter = state != null ?
            new ObjectParameter("State", state) :
            new ObjectParameter("State", typeof(string));


        var proviceParameter = provice != null ?
            new ObjectParameter("Provice", provice) :
            new ObjectParameter("Provice", typeof(string));


        var countryParameter = country != null ?
            new ObjectParameter("Country", country) :
            new ObjectParameter("Country", typeof(string));


        var isActiveParameter = isActive.HasValue ?
            new ObjectParameter("IsActive", isActive) :
            new ObjectParameter("IsActive", typeof(int));


        var isDeletedParameter = isDeleted.HasValue ?
            new ObjectParameter("IsDeleted", isDeleted) :
            new ObjectParameter("IsDeleted", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("spPerson_InsertAddress", streetParameter, numberParameter, postalCodeParameter, cityParameter, stateParameter, proviceParameter, countryParameter, isActiveParameter, isDeletedParameter);
    }


    public virtual int spPerson_InsertPerson(string firstName, string lastName, string middleName, Nullable<int> idNumber, string emailAddress, string phoneNumber, Nullable<int> addressId, Nullable<int> isActive, Nullable<int> isDeleted, Nullable<int> gender, string eMBG)
    {

        var firstNameParameter = firstName != null ?
            new ObjectParameter("FirstName", firstName) :
            new ObjectParameter("FirstName", typeof(string));


        var lastNameParameter = lastName != null ?
            new ObjectParameter("LastName", lastName) :
            new ObjectParameter("LastName", typeof(string));


        var middleNameParameter = middleName != null ?
            new ObjectParameter("MiddleName", middleName) :
            new ObjectParameter("MiddleName", typeof(string));


        var idNumberParameter = idNumber.HasValue ?
            new ObjectParameter("IdNumber", idNumber) :
            new ObjectParameter("IdNumber", typeof(int));


        var emailAddressParameter = emailAddress != null ?
            new ObjectParameter("EmailAddress", emailAddress) :
            new ObjectParameter("EmailAddress", typeof(string));


        var phoneNumberParameter = phoneNumber != null ?
            new ObjectParameter("PhoneNumber", phoneNumber) :
            new ObjectParameter("PhoneNumber", typeof(string));


        var addressIdParameter = addressId.HasValue ?
            new ObjectParameter("AddressId", addressId) :
            new ObjectParameter("AddressId", typeof(int));


        var isActiveParameter = isActive.HasValue ?
            new ObjectParameter("IsActive", isActive) :
            new ObjectParameter("IsActive", typeof(int));


        var isDeletedParameter = isDeleted.HasValue ?
            new ObjectParameter("IsDeleted", isDeleted) :
            new ObjectParameter("IsDeleted", typeof(int));


        var genderParameter = gender.HasValue ?
            new ObjectParameter("Gender", gender) :
            new ObjectParameter("Gender", typeof(int));


        var eMBGParameter = eMBG != null ?
            new ObjectParameter("EMBG", eMBG) :
            new ObjectParameter("EMBG", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spPerson_InsertPerson", firstNameParameter, lastNameParameter, middleNameParameter, idNumberParameter, emailAddressParameter, phoneNumberParameter, addressIdParameter, isActiveParameter, isDeletedParameter, genderParameter, eMBGParameter);
    }


    public virtual int spPerson_UpdateCity(string city, Nullable<int> addressId)
    {

        var cityParameter = city != null ?
            new ObjectParameter("City", city) :
            new ObjectParameter("City", typeof(string));


        var addressIdParameter = addressId.HasValue ?
            new ObjectParameter("AddressId", addressId) :
            new ObjectParameter("AddressId", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spPerson_UpdateCity", cityParameter, addressIdParameter);
    }


    public virtual int spPerson_UpdateEmail(string email, Nullable<int> idNumber)
    {

        var emailParameter = email != null ?
            new ObjectParameter("Email", email) :
            new ObjectParameter("Email", typeof(string));


        var idNumberParameter = idNumber.HasValue ?
            new ObjectParameter("IdNumber", idNumber) :
            new ObjectParameter("IdNumber", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spPerson_UpdateEmail", emailParameter, idNumberParameter);
    }


    public virtual int spPerson_UpdatePerson(Nullable<int> personId, string firstName, string middleName, string lastName, Nullable<int> idNumber, string emailAddress, string phoneNumber, Nullable<int> addressId, Nullable<int> active, Nullable<int> deleted, Nullable<int> gender, string eMBG)
    {

        var personIdParameter = personId.HasValue ?
            new ObjectParameter("PersonId", personId) :
            new ObjectParameter("PersonId", typeof(int));


        var firstNameParameter = firstName != null ?
            new ObjectParameter("FirstName", firstName) :
            new ObjectParameter("FirstName", typeof(string));


        var middleNameParameter = middleName != null ?
            new ObjectParameter("MiddleName", middleName) :
            new ObjectParameter("MiddleName", typeof(string));


        var lastNameParameter = lastName != null ?
            new ObjectParameter("LastName", lastName) :
            new ObjectParameter("LastName", typeof(string));


        var idNumberParameter = idNumber.HasValue ?
            new ObjectParameter("IdNumber", idNumber) :
            new ObjectParameter("IdNumber", typeof(int));


        var emailAddressParameter = emailAddress != null ?
            new ObjectParameter("EmailAddress", emailAddress) :
            new ObjectParameter("EmailAddress", typeof(string));


        var phoneNumberParameter = phoneNumber != null ?
            new ObjectParameter("PhoneNumber", phoneNumber) :
            new ObjectParameter("PhoneNumber", typeof(string));


        var addressIdParameter = addressId.HasValue ?
            new ObjectParameter("AddressId", addressId) :
            new ObjectParameter("AddressId", typeof(int));


        var activeParameter = active.HasValue ?
            new ObjectParameter("Active", active) :
            new ObjectParameter("Active", typeof(int));


        var deletedParameter = deleted.HasValue ?
            new ObjectParameter("Deleted", deleted) :
            new ObjectParameter("Deleted", typeof(int));


        var genderParameter = gender.HasValue ?
            new ObjectParameter("Gender", gender) :
            new ObjectParameter("Gender", typeof(int));


        var eMBGParameter = eMBG != null ?
            new ObjectParameter("EMBG", eMBG) :
            new ObjectParameter("EMBG", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spPerson_UpdatePerson", personIdParameter, firstNameParameter, middleNameParameter, lastNameParameter, idNumberParameter, emailAddressParameter, phoneNumberParameter, addressIdParameter, activeParameter, deletedParameter, genderParameter, eMBGParameter);
    }


    public virtual ObjectResult<spPersonAddress_InnerJoin_Result> spPersonAddress_InnerJoin()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spPersonAddress_InnerJoin_Result>("spPersonAddress_InnerJoin");
    }

        //public System.Data.Entity.DbSet<WebApp.Models.OfferAddEditModel> OfferAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.OfferAddEditModel> OfferAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.NoticeAddEditModel> NoticeAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.AgreementAddEditModel> AgreementAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.AgreementAddEditModel> AgreementAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.InvoiceAddEditModel> InvoiceAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.NoticeAddEditModel> NoticeAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.NoticeAddEditModel> NoticeAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<DMS.Models.OfferAddEditModel> OfferAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<DMS.Models.PersonAddEditModel> PersonAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<DMS.Models.PersonAddEditModel> PersonAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<DMS.Models.PersonAddEditModel> PersonAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<DMS.Models.PersonAddEditModel> PersonAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<DMS.Models.PersonAddEditModel> PersonAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.OrganizationAddEditModel> OrganizationAddEditModels { get; set; }


        //public System.Data.Entity.DbSet<WebApp.Models.OrganizationAddEditModel> OrganizationAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.OrganizationAddEditModel> OrganizationAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.OrganizationAddEditModel> OrganizationAddEditModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.OrganizationAddEditModel> OrganizationAddEditModels { get; set; }
    }

}

