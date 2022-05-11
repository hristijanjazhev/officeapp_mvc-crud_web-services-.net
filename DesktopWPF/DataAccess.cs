using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using DesktopWPF.Models;
using BenchmarkDotNet.Attributes;

namespace DesktopWPF
{
    public class DataAccess
    {
        public int FKAddressId { get; set; }

        #region CREATE
        public void InsertPerson(string firstName, string lastName, string middleName, string idNumber, string emailAddress, string phoneNumber, string addressId, string isActive, string isDeleted, string gender, string personEMBG)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                if (addressId == "")
                {
                    addressId = FKAddressId.ToString();
                }

                connection.Execute($"dbo.spPerson_InsertPerson @FirstName = '{firstName}', @LastName = '{lastName}', @MiddleName = '{middleName}', @IdNumber = '{idNumber}', @EmailAddress = '{emailAddress}', @PhoneNumber = '{phoneNumber}', @AddressId = '{addressId}', @IsActive = '{isActive}', @IsDeleted = '{isDeleted}', @Gender = '{gender}', @EMBG = '{personEMBG}'");
            }
        }
        public void InsertAddress(string street, string number, string postalCode, string city, string state, string province, string country, string isActive, string isDeleted)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                // Anonymous type must be used as QuerySingle or ExecuteScalar does not accept collections (list, array...)
                FKAddressId = connection.QuerySingle<int>("INSERT INTO dbo.Address VALUES(@Street, @Number, @PostalCode, @City, @State, @Province, @Country, @IsActive, @IsDeleted); SELECT SCOPE_IDENTITY();", new { street, number, postalCode, city, state, province, country, isActive, isDeleted });
            }
        }
        public void InsertOrganiation(string organizationName, string companyId, string vatNumber, string description, string email, string phoneNumber, string type, string addressId, string isActive, string isDeleted)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                if (addressId == "")
                {
                    addressId = FKAddressId.ToString();
                }

                connection.Execute("INSERT INTO dbo.Organization VALUES(@OrganizationName, @CompanyId, @VatNumber, @Description, @Email, @PhoneNumber, @Type, @AddressId, @IsActive, @IsDeleted); SELECT SCOPE_IDENTITY();", new { organizationName, companyId, vatNumber, description, email, phoneNumber, type, addressId, isActive, isDeleted });
            }
        }
        #endregion 
        
        #region READ
        [Benchmark]
        public List<Person> GetPeople(string personLastName, string personEMBG)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                if (personLastName == "" && personEMBG == "")
                {
                    List<Person> getAllPeople = connection.Query<Person>("SELECT * FROM dbo.Person").ToList();
                    return getAllPeople;
                }
                else
                {
                    List<Person> output = connection.Query<Person>("dbo.spPerson_GetLastName @PersonLastName, @EMBG", new { PersonLastName = personLastName, EMBG = personEMBG }).ToList();
                    return output;
                }
            }
        }
        public List<Address> GetAddresses(string street, string number)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                FKAddressId = connection.QueryFirstOrDefault<int>($"SELECT * FROM dbo.Address WHERE Street = '{street}' AND Number = '{number}'");

                if (street == "" && number == "")
                {
                    List<Address> getAllAddresses = connection.Query<Address>("SELECT * FROM dbo.Address").ToList();
                    return getAllAddresses;
                }
                else
                {
                    List<Address> output = connection.Query<Address>("dbo.spAddress_GetAddress @Street, @Number", new { Street = street, Number = number }).ToList();
                    return output;
                }
            }
        }
        public List<Organization> GetOrganizations(string organizationName, string companyId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                if (organizationName == "" && companyId == "")
                {
                    List<Organization> getAllOrganizations = connection.Query<Organization>("SELECT * FROM dbo.Organization").ToList();
                    return getAllOrganizations;
                }
                else
                {
                    List<Organization> output = connection.Query<Organization>("dbo.spOrganization_GetOrganization @OrganizationName, @CompanyId", new { OrganizationName = organizationName, CompanyId = companyId }).ToList();
                    return output;
                }
            }
        }
        #endregion

        #region UPDATE
        public void UpdatePerson(int foreignKey, string firstName, string middleName, string lastName, string idNumber, string emailAddress, string phoneNumber, string addressId, string isActive, string isDeleted, string gender, string embg)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                // Stored procedure parameters must be written exactly as they are in the original stored procedure in SSMS.
                connection.Execute($"dbo.spPerson_UpdatePerson @PersonId = '{foreignKey}', @FirstName = '{firstName}', @MiddleName = '{middleName}', @LastName = '{lastName}', @IdNumber = '{idNumber}', @EmailAddress = '{emailAddress}', @PhoneNumber = '{phoneNumber}', @AddressId = '{addressId}', @Active = '{isActive}', @Deleted = '{isDeleted}', @Gender = '{gender}', @EMBG = '{embg}'");

                // When using pure SQL code, parameters must be written exactly as the names of the columns in SSMS.
                //connection.Execute($"UPDATE dbo.Person SET PersonFirstName = '{firstName}', PersonMiddleName = '{middleName}', PersonLastName = '{lastName}', IdNumber = '{idNumber}', Email = '{emailAddress}', PhoneNumber = '{phoneNumber}', AddressId = '{addressId}', IsActive = '{isActive}', IsDeleted = '{isDeleted}', Gender = '{gender}', EMBG = '{embg}' WHERE PersonId = '{foreignKey}'");
            }
        }

        public void UpdateAddresss(int foreignKey, string street, string number, string postalCode, string city, string state, string province, string country, string isActive, string isDeleted)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                connection.Execute($"dbo.spAddress_Update @AddressId = '{foreignKey}', @Street = '{street}', @Number = '{number}', @PostalCode = '{postalCode}', @City = '{city}', @State = '{state}', @Province = '{province}', @Country = '{country}', @Active = '{isActive}', @Deleted = '{isDeleted}'");
            }
        }

        public void UpdateOrganization(int foreignKey, string organizationName, string companyId, string vatNumber, string description, string email, string phoneNumber, string type, string addressId, string isActive, string isDeleted)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                connection.Execute($"dbo.spOrganization_UpdateOrganization @OrganizationId = '{foreignKey}', @OrganizationName = '{organizationName}', @CompanyId = '{companyId}', @VatNumber = '{vatNumber}', @Description = '{description}', @Email = '{email}', @PhoneNumber = '{phoneNumber}', @Type = '{type}', @AddressId = '{addressId}', @Active = '{isActive}', @Deleted = '{isDeleted}'");
            }
        }
        #endregion

        #region DELETE
        public void DeletePerson(int foreignKey)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                connection.Execute($"dbo.spPerson_Delete @PersonId = '{foreignKey}'");
            }
        }

        // Reconsidering if deleting address is actually needed.
        public void DeleteAddress(int foreignKey)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                connection.Execute($"dbo.spAddress_Delete @AddressId = '{foreignKey}'");
            }
        }

        public void DeleteOrganization(int foreignKey)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
            {
                connection.Execute($"dbo.spOrganization_Delete @OrganizationId = '{foreignKey}''");
            }
        }
        #endregion

    }
}