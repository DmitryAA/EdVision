from django.db import models
from django.contrib.auth.models import User
class Address(models.Model):
	address_string = models.CharField(max_length = 200, verbose_name = 'Адрес')
	phone = models.CharField(max_length = 30, verbose_name = 'Телефон')
	email = models.CharField(max_length = 30, verbose_name = 'email адрес')
	link = models.CharField(max_length = 40, verbose_name = 'ссылка')

class Students(models.Model):
    first_name = models.CharField(max_length = 100, verbose_name = 'Имя')
    last_name = models.CharField(max_length = 100, verbose_name = 'Фамилия')
    patronimic_name = models.CharField(max_length = 100, verbose_name = 'Отчество')
    birtday = models.DateField(verbose_name = 'Дата рождения')
    id_address = models.ForeignKey(Address, on_delete=models.PROTECT)
    id_auth = models.ForeignKey(User, on_delete=models.CASCADE)
  

class City(models.Model):
	name = models.CharField(max_length = 70, verbose_name = 'Название города')
	id_Region = models.IntegerField

class Region(models.Model):
	name = models.CharField(max_length = 90, verbose_name = 'Название региона')

	