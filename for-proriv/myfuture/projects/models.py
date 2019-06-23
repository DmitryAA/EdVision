from django.db import models
from students.models import Students
from universites.models import Direction, Department
from companies.models import Companies

class Project(models.Model):
	name = models.CharField(max_length = 200, verbose_name = 'НАзвание фирмы')
	description = models.CharField(max_length = 200, verbose_name = 'Юридич название')
	comment = models.CharField(max_length = 300, verbose_name = 'Описание')
	start_date = models.CharField(max_length = 20, verbose_name = 'ИНН')
	end_date = models.CharField(max_length = 20, verbose_name = 'ОГРН')
	type_prj = models.IntegerField
	category = models.IntegerField
	id_direction = models.ForeignKey(Direction, on_delete=models.PROTECT)
	id_company = models.ForeignKey(Companies, on_delete=models.PROTECT)
	id_department = models.ForeignKey(Department, on_delete=models.PROTECT)

class Grade(models.Model):
	value = models.IntegerField
	comment = models.CharField(max_length = 100, verbose_name = 'Коммент')
	id_student = models.ForeignKey(Students, on_delete=models.PROTECT)
