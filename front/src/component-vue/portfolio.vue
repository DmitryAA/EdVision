<template>
	<div class="b-portfolio row">
		<div v-if="info" class="b-portfolio__info">
			<h1>{{info.LastName}} {{info.FirstName}} {{info.PatronimicName}}</h1>
			<p>Выполненно с провекркой задач: {{info.Tasks.length}}</p>
		</div>
		<div v-if="info" class="b-portfolio__tasks">
			<h2>Работы</h2>
			<section v-for="item in info.Tasks">
				<article>
					<h3>{{item.Name}}</h3>
					<div><strong>Дата сдачи</strong>: {{item.EndDate}} </div>
					<div><strong>Резюме преподователя ({{item.LecturerGrade.GradingPerson.LastName}})</strong>: {{item.LecturerGrade.Comment}} </div>
					<div><strong>Резюме ментора ({{item.MentorGrade.GradingPerson.LastName}})</strong>: {{item.MentorGrade.Comment}} </div>
				</article>
			</section>
		</div>
	</div>
</template>

<script>
	import axios from 'axios';

	export default {
		name: 'student',
		data() {
			return {
				info: null
			};
		},
		mounted() {
			axios
				.get('http://192.168.0.30:1488/api/students/' + this.$route.params.id)
				.then(response => (this.info = response.data));
		}
	};
</script>
