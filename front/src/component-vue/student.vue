<template>
	<div class="b-student row">
		<div v-if="info" class="b-student__info">
			<h1>{{info.LastName}} {{info.FirstName}} {{info.PatronimicName}}</h1>
			<p>Выполненно с провекркой задач: {{info.Tasks.length}}</p>
			<input type="submit" @click="request" value="Запросить резюме">
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
		computed: {
			url: function() {
				return 'http://192.168.0.30:1488/api/student/' + this.info.Id + '/portfolio';
			}
		},
		methods: {
			request: function() {
				alert('Запрос отправлен студенту, после положительного ответа вы получите доступ для просмотра');
				this.$router.push({ path: '/student/' + this.info.Id + '/portfolio'});
				return false;
			},
		},
		mounted() {
			axios
				.get('http://192.168.0.30:1488/api/students/' + this.$route.params.id)
				.then(response => (this.info = response.data));
		}
	};
</script>
