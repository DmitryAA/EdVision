from django.db import models
from students.models import Address
from django.contrib.auth.models import User

class Universities(models.Model):
	name = models.CharField(max_length = 200, verbose_name = 'НАзвание фирмы')
	FederalRaiting = models.CharField(max_length = 20, verbose_name = 'Юридич название')
	MeanGrants = models.CharField(max_length = 30, verbose_name = 'Описание')
	HostelPrice = models.CharField(max_length = 20, verbose_name = 'ИНН')
	id_address = models.ForeignKey(Address, on_delete=models.PROTECT)
	id_auth = models.ForeignKey(User, on_delete=models.CASCADE)

class Department(models.Model):
	name = models.CharField(max_length = 100, verbose_name = 'Название кафедры')
	id_Universities = models.ForeignKey(Universities, on_delete=models.PROTECT)

class Direction(models.Model):
	name = models.CharField(max_length = 100, verbose_name = 'Название направления')
	description = models.CharField(max_length = 100, verbose_name = 'Направление обучения')

