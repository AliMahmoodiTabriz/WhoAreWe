using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConnectionBusiness.Constants
{
    public static class Messages
    {
        //error code 1000 for connection exceptions reserve

        public static string UserDeleted = "User successfully deleted";
        public static string UserDeletedId = "10101";
        public static string UserUpdated = "User successfully updated";
        public static string UserUpdatedId = "10103";

        public static string UserOperationClaimAdded = "User Operation Claim successfully added";
        public static string UserOperationClaimAddedId = "10200";

        public static string AfwListIsEmpty = "Afw List Is Empty";
        public static string AfwListIsEmptyId = "10300";

        public static string AccessTokenCreated = "User Access token successfully created";
        public static string AccessTokenCreatedId = "10400";
        public static string UserNotFound = "User not found";
        public static string UserNotFoundId = "10401";
        public static string PasswordError = "User Password error";
        public static string PasswordErrorId = "10402";
        public static string SuccessfulLogin = "User successful Login";
        public static string SuccessfulLoginId = "10403";
        public static string UserRegistered = "User successfully registered";
        public static string UserRegisteredId = "10404";
        public static string UserNotAvailable = "User not available";
        public static string UserNotAvailableId = "10405";
        public static string PasswordReset = "Password Successfully Reset";
        public static string PasswordResetId = "10407";
        public static string UserAlreadyExists = "User already exists";
        public static string UserAlreadyExistsId = "10408";
        public static string UserIsNotActive = "User Is Not Actived";
        public static string UserIsNotActiveId = "10410";
        public static string RecoveryPassword = "Recovery password successfully , plase check email";
        public static string RecoveryPasswordId = "10411";


        public static string ClaimAdded = "Claim successfully added";
        public static string ClaimAddedId = "10600";
        public static string ClaimDeleted = "Claim successfully deleted";
        public static string ClaimDeletedId = "10601";
        public static string ClaimUpdated = "Claim successfully updated";
        public static string ClaimUpdatedId = "10602";


        public static string ClientAdded = "Project successfully added";
        public static string ClientAddedId = "11400";
        public static string ClientDeleted = "Project successfully deleted";
        public static string ClientDeletedId = "11401";
        public static string ClientUpdated = "Project successfully updated";
        public static string ClientUpdatedId = "11402";
        public static string ClientNameNotEmpty = "Project name cannot be empty";
        public static string ClientNameAlreadyExists = "Project Name Already Exists";
        public static string ClientNameAlreadyExistsId = "11403";
        public static string ClientNameIsNotExists = "Project Is Not Already Exists";
        public static string ClientNameIsNotExistsId = "11404";

        public static string AuthorizeationDenied = "Authorizeation Denied";
        public static string AuthorizeationDeniedId = "11600";
        public static string AuthenticationDenied = "authentication Denied, Please Try Logging In Again";
        public static string AuthenticationDeniedId = "11601";
    }
}
