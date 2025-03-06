using System.ComponentModel;

namespace MongoDBCars.Enums
{
    public enum ApiError
    {
        // Generic
        [Description("Some unexpected thing heppened")]
        SOME_THING_GOES_WRONG,

        // Cars
        [Description("Brand is a required field")]
        BRAND_IS_REQUIRED,
        [Description("Car Plate is a required field")]
        CARPLATE_IS_REQUIRED,
        [Description("There is not any car refeerenced by id passed")]
        CAR_NOT_FOUND_ID,
        [Description("Customer name is a required field")]
        Customer_NAME_EMPTY,
        [Description("Customer email is a required field")]
        Customer_EMAIL_EMPTY,
        [Description("Password must have at least 8 characters, 1 lower an uppercase char and 1 special char")]
        STRONG_PASSWORD_REQUIRED,
        [Description("Customer password is a required field")]
        PASSWORD_REQUIRED,
        [Description("Email should be a valid one")]
        INVALID_EMAIL,
        [Description("Car plate should be a valid one")]
        INVALID_CAR_PLATE,

        // User

        // Customer
        [Description("Customer not found")]
        CUSTOMER_NOT_FOUND,

        // Employee
        [Description("Salary is a required field")]
        SALARY_IS_REQUIRED,
        [Description("Salary must be greater than zero")]
        NEGATIVE_SALARY,
        [Description("Position is a required field")]
        POSITION_IS_REQUIRED,
        [Description("Employeer not found")]
        EMPLOYEE_NOT_FOUND,
    }
}
