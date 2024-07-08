using Business.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WebData.Entities;

namespace Business.Validators;

public static class PatientValidator
{
    public static void Validate(Patient patient)
    {
        if (string.IsNullOrEmpty(patient.SurName))
            throw new Exception("Фамилия не должна быть пустой");
        if (string.IsNullOrEmpty(patient.Name))
            throw new Exception("Имя не должно быть пустым");
        if (patient.DateOfBirth > DateOnly.FromDateTime(DateTime.Today))
            throw new Exception("Дата рождения не может быть больше текущей");
        if (patient.Sex != "ж" && patient.Sex != "м")
            throw new Exception("Не верно введен пол пациента! Введите 'м' или 'ж'!");
        if (string.IsNullOrEmpty(patient.Address))
            throw new Exception("Адрес не должен быть пустым");
    }

}
