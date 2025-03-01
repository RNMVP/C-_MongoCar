using System.ComponentModel;

namespace MongoDBCars.Enums
{
    public enum ApiError
    {
        // Generic
        [Description("Some unexpected thing heppened")]
        SOME_THING_GOES_WRONG = 0,

        // Cars
        [Description("Brand is a required field")]
        BRAND_IS_REQUIRED = 1,
        [Description("Car Plate is a required field")]
        CARPLATE_IS_REQUIRED = 2,
        [Description("There is not any car refeerenced by id passed")]
        CAR_NOT_FOUND_ID = 3,
        [Description("Customer name is a required field")]
        Customer_NAME_EMPTY = 4,
        [Description("Customer email is a required field")]
        Customer_EMAIL_EMPTY = 5,
        [Description("Password must have at least 8 characters, 1 lower an uppercase char and 1 special char")]
        STRONG_PASSWORD_REQUIRED = 6,
        [Description("Customer password is a required field")]
        PASSWORD_REQUIRED = 7,
        [Description("Email should be a valid one")]
        INVALID_EMAIL = 8,
        [Description("Car plate should be a valid one")]
        INVALID_CAR_PLATE = 9,

        // User

        // Customer

        // Employee
        [Description("Salary is a required field")]
        SALARY_IS_REQUIRED = 10,
        [Description("Salary must be greater than zero")]
        NEGATIVE_SALARY = 11,
        [Description("Position is a required field")]
        POSITION_IS_REQUIRED = 12,
    }
}
