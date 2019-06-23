from django.db import models
from students.models import Address
from django.contrib.auth.models import User

class Companies(models.Model):
	name = models.CharField(max_length = 200, verbose_name = 'НАзвание фирмы')
	legalName = models.CharField(max_length = 200, verbose_name = 'Юридич название')
	description = models.CharField(max_length = 300, verbose_name = 'Описание')
	inn = models.CharField(max_length = 20, verbose_name = 'ИНН')
	ogrn = models.CharField(max_length = 20, verbose_name = 'ОГРН')
	id_address = models.ForeignKey(Address, on_delete=models.PROTECT)
	id_auth = models.ForeignKey(User, on_delete=models.CASCADE)


